using TradieApp.Domain.Categories;
using TradieApp.Domain.Common;
using TradieApp.Domain.Locations;

namespace TradieApp.Domain.Entities;

public class Job : Entity
{
    public Job(int id, string status, Suburb suburb, Category category, Contact contact, int price, string description, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Status = status;
        Suburb = suburb;
        Category = category;
        Contact = contact;
        Price = price;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public int Id { get; private set; }
    public string Status { get; private set; }
    public Suburb Suburb { get; private set; }
    public Category Category { get; private set; }
    public Contact Contact { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}