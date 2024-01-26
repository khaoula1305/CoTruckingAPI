using AutoMapper;
using Cotrucking.Domain.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Domain.Models.Common;

namespace Cotrucking.Domain.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region City
            CreateMap<CityDataModel, CityResponse>();
            CreateMap<CityDataModel, KeyValueModel>()
                .ForMember(src => src.Key, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.Value, opt => opt.MapFrom(x => x.Name));
            CreateMap<CityInput, CityDataModel>();
            #endregion

            #region Country
            CreateMap<CountryDataModel, CountryResponse>();
            CreateMap<CountryDataModel, KeyValueModel>()
                .ForMember(src => src.Key, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.Value, opt => opt.MapFrom(x => x.Name));
            CreateMap<CountryInput, CountryDataModel>();
            #endregion

            #region Transprter
            CreateMap<TransporterDataModel, TransporterResponse>();
            CreateMap<TransporterDataModel, KeyValueModel>()
                .ForMember(src => src.Key, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.Value, opt => opt.MapFrom(x => x.User == null ? string.Empty : $"{x.User.Lastname} {x.User.Firstname}"));
            CreateMap<TransporterInput, TransporterDataModel>();
            #endregion

            #region Shipment
            CreateMap<ShipmentDataModel, ShipmentResponse>();
            CreateMap<ShipmentDataModel, KeyValueModel>()
                .ForMember(src => src.Key, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.Value, opt => opt.MapFrom(x => x.Name));
            CreateMap<ShipmentInput, ShipmentDataModel>();
            #endregion

            #region Company
            CreateMap<CompanyDataModel, CompanyResponse>();
            CreateMap<CompanyDataModel, KeyValueModel>()
                .ForMember(src => src.Key, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.Value, opt => opt.MapFrom(x => x.Name));
            CreateMap<CompanyInput, CompanyDataModel>();
            #endregion
        }
    }
}
