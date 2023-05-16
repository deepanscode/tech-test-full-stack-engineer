using System;
using AutoMapper;
using MediatR;
using TradieApp.Application.Common.Parameters;
using TradieApp.Application.Common.Wrappers;
using TradieApp.Application.Features.Jobs.DTO;
using TradieApp.Application.Repository;
using TradieApp.Application.Specifications;
using TradieApp.Domain.Categories;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Enums;
using TradieApp.Domain.Locations;

namespace TradieApp.Application.Features.Jobs.Queries;

public class GetJobsQuery : PagedRequestParameter, IRequest<PagedCollection<GetJobsQueryResponseDto>>
{
    public JobStatusEnum JobStatus { get; set; }

}

public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, PagedCollection<GetJobsQueryResponseDto>>
{
    private readonly IRepository<Job> _jobRepository;
    private readonly IMapper _mapper;

    public GetJobsQueryHandler(IRepository<Job> jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<PagedCollection<GetJobsQueryResponseDto>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobSpecification = new QuerySpecification<Job>();
        jobSpecification.AddNotracking();
        jobSpecification.AddWhere(it => it.Status == request.JobStatus);
        jobSpecification.AddInclude(it => it.Category);
        jobSpecification.AddInclude(it => it.Suburb);
        jobSpecification.SetPaging(request.Skip, request.Take);

        var totalRecordCount = await _jobRepository.CountAsync(jobSpecification);

        var jobs = await _jobRepository.ListAsync(jobSpecification);

        var response = jobs.Select(job => _mapper.Map<GetJobsQueryResponseDto>(job)).ToList();

        return new PagedCollection<GetJobsQueryResponseDto>(response, request.PageNumber, request.PageSize, totalRecordCount);
    }
}

