using AutoMapper;
using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Exceptions;
using Cotrucking.Domain.Extensions;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cotrucking.Services.Services
{
    public interface IUserService : IGenericService<UserDataModel, UserResponse>
    {
        Task<TokenModel?> Login(LoginModel login);
        Task<TokenModel> RefreshToken(RefreshTokenRequest refreshTokenRequest);
        Task Register(UserInput user);
    }

    public class UserService(
        IUserRepository userRepository, 
        IMapper mapper, 
        IHttpContextAccessor httpContextAccessor, 
        UserManager<UserDataModel> userManager,
        RoleManager<RoleDataModel> roleManager, 
        IOptions<AppSettings> appSettings,
        IRefreshTokenRepository refreshTokenRepository,
        TokenValidationParameters tokenValidationParameters)
        : GenericService<UserDataModel, UserResponse>(userRepository, mapper, httpContextAccessor), IUserService
    {

        public async Task<TokenModel?> Login(LoginModel login)
        {
            if(login.UserName== null || login.Password == null)
            {
                throw new ResponseException();
            }
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user != null  && await userManager.CheckPasswordAsync(user, login.Password)) 
            {
                var tokenValue = await GenerateJWTTokenAsync(user, null);
                return tokenValue;
            }
            return null;
        }

        private async Task<TokenModel> GenerateJWTTokenAsync(UserDataModel user, RefreshTokenDataModel refreshTokenInput)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var item in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Value.Jwt.Secret));
            var token = new JwtSecurityToken(
                issuer: appSettings.Value.Jwt.Issuer, 
                audience: appSettings.Value.Jwt.Audience,
                claims: authClaims, 
                expires: DateTime.UtcNow.AddMinutes(appSettings.Value.Jwt.TokenDuration),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            if (refreshTokenInput != null)
            {
                var response = new TokenModel
                {
                    Token = jwtToken,
                    ExpiresAt = token.ValidTo,
                    RefreshToken = refreshTokenInput.Token
                };
                return response;
            }
            var refreshToken = new RefreshTokenDataModel()
            {
                JwtId = token.Id,
                IsRevoked = false,
                DateAdded = DateTime.UtcNow,
                DateExpire = DateTime.UtcNow.AddMonths(6),
                Token = $"{Guid.NewGuid().ToString()}-{Guid.NewGuid().ToString()}",
                UserId = user.Id,
            };
            await refreshTokenRepository.InsertAsync(refreshToken);
            await refreshTokenRepository.SaveChangesAsync();
            return new TokenModel
            {
                Token = jwtToken,
                ExpiresAt = token.ValidTo,
                RefreshToken = refreshToken.Token
            };
        }

        protected bool IsPasswordComplex(string password)
        {
            return password.Any(char.IsDigit) && password.Any(char.IsLower) && password.Any(char.IsUpper) && password.Length > 8 && password.Any(char.IsSymbol);
        }

        public async Task Register(UserInput user)
        {
            var userExists = await userManager.FindByEmailAsync(user.Email);
            if (userExists != null) 
            {
                throw new ResponseException(ErrorConstants.AlreadyExists);
            }
            if (!IsPasswordComplex(user.Password))
            {
                throw new ResponseException(ErrorConstants.PasswordNotComplicated);
            }
            var newUser = mapper.Map<UserDataModel>(user);
            newUser.SecurityStamp = Guid.NewGuid().ToString();
            var result = await userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                throw new ResponseException(ErrorConstants.UserNotCreated);
            }
            //userManager.AddToRoleAsync(newUser, user.RoleId);

        }

        public async Task<TokenModel> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var storedToken = await refreshTokenRepository.FindFirstOrDefaultAsync(x => x.Token == refreshTokenRequest.RefreshToken);
            var dbUser = await userManager.FindByIdAsync(storedToken.UserId.ToString());

            try
            {
                var tokenCheckResult = jwtTokenHandler.ValidateToken(refreshTokenRequest.Token, tokenValidationParameters,out var validatedToken);
                return await GenerateJWTTokenAsync(dbUser, storedToken);
            }
            catch (SecurityTokenExpiredException ex)
            {
                if(storedToken.DateExpire >= DateTime.UtcNow)
                {
                    return await GenerateJWTTokenAsync(dbUser,storedToken);
                }
                else
                {
                    return await  GenerateJWTTokenAsync(dbUser, null);

                }
            }
        }
    }
}
