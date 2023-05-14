using TradieApp.Domain.Common;

namespace TradieApp.Domain.Categories;

public class Category : Entity
{
    public Category(int id, string name, int? parentCategoryId = null)
    {
        Id = id;
        Name = name;
        ParentCategoryId = parentCategoryId;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int? ParentCategoryId { get; private set; }
    public Category? ParentCategory { get; private set; }
}