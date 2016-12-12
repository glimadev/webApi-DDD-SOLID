using AutoMapper;
using Api.Architecture.Domain.Common;
using Api.Architecture.Domain.Out;
using Api.Architecture.Web.VM.Common;
using Api.Architecture.Web.VM.Out;

namespace Api.CenarioCapital.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ResultService, ResultServiceVM>();
            Mapper.CreateMap<UserGetAllNamesOut, UserGetAllNamesOutVM>();
        }
    }
}