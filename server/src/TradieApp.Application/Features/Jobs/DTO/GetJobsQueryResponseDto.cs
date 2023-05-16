using TradieApp.Domain.Categories;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Enums;
using TradieApp.Domain.Locations;

namespace TradieApp.Application.Features.Jobs.DTO;

public class GetJobsQueryResponseDto
{
    public int Id { get; private set; }
    public JobStatusEnum Status { get; private set; }

    public int SuburbId { get; set; }
    public string SuburbName { get; private set; }
    public string Postcode { get; private set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; private set; }

    public string ContactName { get; private set; }
    public string ContactPhone { get; private set; }
    public string ContactEmail { get; private set; }

    public int Price { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}

