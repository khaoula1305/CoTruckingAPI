using AutoMapper;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface IDriverService : IGenericService<DriverDataModel, DriverResponse> 
    {
    }

    public class DriverService(IDriverRepository transporterRepository, IMapper mapper, IHttpContextAccessor httpContext) : GenericService<DriverDataModel, DriverResponse>(transporterRepository, mapper, httpContext), IDriverService
    {

        public override async Task<DriverResponse> AddAsync<DriverInput>(DriverInput entity)
        {
            var repoEntity = mapper.Map<DriverDataModel>(entity);
            await transporterRepository.InsertAsync(repoEntity);
            await transporterRepository.SaveChangesAsync();
            return mapper.Map<DriverResponse>(repoEntity);
        }
    }
}
