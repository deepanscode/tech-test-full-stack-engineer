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
				.ConstructUsing(src => new GetJobsQueryResponseDto(
					src.Id, 
					src.Status, 
					src.Suburb.Name,
					src.Suburb.Postcode, 
					src.Category.Name, 
					src.Contact.Name, 
					src.Contact.Phone, 
					src.Contact.Email,
					src.Price, 
					src.Description, 
					src.CreatedAt, 
					src.UpdatedAt));
		}
	}
}

