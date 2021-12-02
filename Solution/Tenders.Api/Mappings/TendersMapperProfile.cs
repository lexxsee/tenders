using AutoMapper;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;

namespace Tenders.Api.Mappings
{
    public class TendersMapperProfile : Profile
    {
        public TendersMapperProfile()
        {
            CreateMap<CitizenDocument, CitizenDocumentDto>().ReverseMap();
            CreateMap<CitizenDocumentType, CitizenDocumentTypeDto>().ReverseMap();
            CreateMap<Citizen, CitizenDto>().ReverseMap();
        }
    }
}
