using System.Collections.Generic;
using AutoMapper;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;
using Tenders.Core.Enums;

namespace Tenders.Api.Mappings
{
    public class TendersMapperProfile : Profile
    {
        public TendersMapperProfile()
        {
            CreateMap<CitizenDocument, CitizenDocumentDto>(MemberList.Destination).ReverseMap();
            CreateMap<Citizen, CitizenDto>(MemberList.Destination).ReverseMap();
            CreateMap<CitizenRequestDto, Citizen>()
                .ForMember(dest => dest.CitizenDocuments, m => m.MapFrom(src =>
                    new List<CitizenDocument>
                    {
                        new() { Number = src.Inn, TypeId = (int)CitizenDocumentTypeEnum.ИИН },
                        new() { Number = src.Snils, TypeId = (int)CitizenDocumentTypeEnum.СНИЛС }
                    }
                ));

            CreateMap<CitizenDocumentType, CitizenDocumentTypeDto>(MemberList.Destination);
        }
    }
}