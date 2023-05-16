using TradieApp.Domain.Categories;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Enums;
using TradieApp.Domain.Locations;

namespace TradieApp.Application.Features.Jobs.DTO;

public record GetJobsQueryResponseDto(
    int Id,
    JobStatusEnum Status,
    string SuburbName,
    string Postcode,
    string CategoryName,
    string ContactName,
    string ContactPhone,
    string ContactEmail,
    int Price,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt
);


