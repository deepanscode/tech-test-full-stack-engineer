using FluentValidation;
using TradieApp.Application.Features.Jobs.Queries;

namespace TradieApp.Application.Features.Jobs.Validations;

public class GetJobsQueryValidator : AbstractValidator<GetJobsQuery>
{
	public GetJobsQueryValidator()
	{
		RuleFor(it => it.JobStatus).NotEmpty();
		RuleFor(it => it.JobStatus).NotEqual(Domain.Enums.JobStatusEnum.none).WithMessage("Invalid job status value");
	}
}
