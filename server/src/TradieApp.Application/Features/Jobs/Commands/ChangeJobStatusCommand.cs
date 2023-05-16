using System;
using System.Runtime.Serialization;
using AutoMapper;
using MediatR;
using TradieApp.Application.Common.Exceptions;
using TradieApp.Application.Common.Parameters;
using TradieApp.Application.Common.Wrappers;
using TradieApp.Application.Features.Jobs.DTO;
using TradieApp.Application.Repository;
using TradieApp.Application.Specifications;
using TradieApp.Application.UnitOfWork;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Enums;

namespace TradieApp.Application.Features.Jobs.Commands;

public record ChangeJobStatusCommand(int JobId, JobStatusEnum JobStatus) : IRequest<bool>;

public class ChangeJobStatusCommandHandler : IRequestHandler<ChangeJobStatusCommand, bool>
{
    private readonly IRepository<Job> _jobRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeJobStatusCommandHandler(IRepository<Job> jobRepository, IUnitOfWork unitOfWork)
    {
        _jobRepository = jobRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(ChangeJobStatusCommand request, CancellationToken cancellationToken)
    {
        var jobSpecification = new QuerySpecification<Job>();
        jobSpecification.AddWhere(it => it.Id == request.JobId);

        var job = await _jobRepository.FirstOrDefaultAsync(jobSpecification);

        if (job == null)
        {
            throw new NotFoundException("Job not found"); 
        }

        if (job.Status != JobStatusEnum.@new) {
            throw new BadRequestException("Invalid job");
        }

        job.Status = request.JobStatus;
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
