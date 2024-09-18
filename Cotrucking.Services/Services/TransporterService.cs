using AutoMapper;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface ITransporterService : IGenericService<TransporterDataModel, TransporterResponse> 
    {
    }

    public class TransporterService(ITransporterRepository transporterRepository, IMapper mapper, IHttpContextAccessor httpContext) : GenericService<TransporterDataModel, TransporterResponse>(transporterRepository, mapper, httpContext), ITransporterService
    {

        public override async Task<TransporterResponse> AddAsync<TransporterInput>(TransporterInput entity)
        {
            var repoEntity = mapper.Map<TransporterDataModel>(entity);
            await transporterRepository.InsertAsync(repoEntity);
            await transporterRepository.SaveChangesAsync();
            return mapper.Map<TransporterResponse>(repoEntity);
        }
    }
}
