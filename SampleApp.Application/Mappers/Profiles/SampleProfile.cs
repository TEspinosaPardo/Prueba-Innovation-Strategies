using AutoMapper;

namespace SampleApp.Application.Mappers.Profiles
{
    /// <summary>
    /// Automatic mappings profile
    /// </summary>
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            // SubSample maps
            CreateMap<Domain.Entities.SubSample, Application.Contracts.DTO.SubSample>();
            CreateMap<Application.Contracts.DTO.SubSample, Domain.Entities.SubSample>();

            // Sample maps
            CreateMap<Application.Contracts.DTO.SampleForCreate, Domain.Entities.Sample>();
            CreateMap<Application.Contracts.DTO.SampleForUpdate, Domain.Entities.Sample>();
            CreateMap<Domain.Entities.Sample, Application.Contracts.DTO.SampleForRead>();
        }
    }
}
