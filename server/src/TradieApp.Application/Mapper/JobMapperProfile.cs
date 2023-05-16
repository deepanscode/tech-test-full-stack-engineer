using System;
using AutoMapper;
using TradieApp.Application.Features.Jobs.DTO;
using TradieApp.Domain.Entities;

namespace TradieApp.Application.Mapper
{
	public class JobMapperProfile : Profile
	{
		public JobMapperProfile()
		{
			CreateMap<Job, GetJobsQueryResponseDto>()
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.SuburbName, opt => opt.MapFrom(src => src.Suburb.Name))
				.ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.Name))
				.ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.Contact.Phone))
				.ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.Contact.Email))
				.ForMember(dest => dest.Postcode, opt => opt.MapFrom(src => src.Suburb.Postcode));
        }
	}
}

