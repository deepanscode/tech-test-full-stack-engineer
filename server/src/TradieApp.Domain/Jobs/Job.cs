using TradieApp.Domain.Categories;
using TradieApp.Domain.Common;
using TradieApp.Domain.Enums;
using TradieApp.Domain.Locations;

namespace TradieApp.Domain.Entities;

public class Job : Entity
{
    public Job(JobStatusEnum status, int price, string description, DateTime createdAt, DateTime updatedAt, Contact contact, Suburb suburb, Category category)
    {
        if (string.IsNullOrEmpty(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));
        if (price <= 0)
            throw new ArgumentException("Price must be positive", nameof(price));

        Status = status;
        Price = price;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Contact = contact;
        Suburb = suburb;
        Category = category;
    }

    public JobStatusEnum Status { get; private set; }
    public Suburb Suburb { get; private set; }
    public Category Category { get; private set; }
    public Contact Contact { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void UpdateStatus(JobStatusEnum newStatus)
    {
        // Only "new" jobs can have their status updated.
        if (Status != JobStatusEnum.@new)
            throw new InvalidOperationException("Only new jobs can have their status updated.");

        // The new status must be either "accepted" or "declined".
        if (newStatus != JobStatusEnum.accepted && newStatus != JobStatusEnum.declined)
            throw new ArgumentException("New status must be either accepted or declined.", nameof(newStatus));

        Status = newStatus;
    }
    
    public Job(JobStatusEnum status, int price, string description, DateTime createdAt, DateTime updatedAt) 
        : this(status, price, description, createdAt, updatedAt, null!, null!, null!)
    {
    }
    
}

