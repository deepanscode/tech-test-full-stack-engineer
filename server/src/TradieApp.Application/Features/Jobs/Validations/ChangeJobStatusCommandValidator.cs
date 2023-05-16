using System;
using FluentValidation;
using TradieApp.Application.Features.Jobs.Commands;
using TradieApp.Application.Features.Jobs.Queries;

namespace TradieApp.Application.Features.Jobs.Validations
{
	public class ChangeJobStatusCommandValidator : AbstractValidator<ChangeJobStatusCommand>
    {
		public ChangeJobStatusCommandValidator()
		{
            RuleFor(it => it.JobId).NotEqual(0);
            RuleFor(it => it.JobStatus).NotEmpty();
            RuleFor(it => it.JobStatus).NotEqual(Domain.Enums.JobStatusEnum.none).WithMessage("Invalid job status value");
            RuleFor(it => it.JobStatus).NotEqual(Domain.Enums.JobStatusEnum.@new).WithMessage("Invalid job status value");
        }
	}
}

