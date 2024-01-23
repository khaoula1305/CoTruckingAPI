using AutoMapper;
using Cotrucking.Domain.Entities;
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
    }
}
