using TradieApp.Domain.Common;

namespace TradieApp.Domain.Locations;

public class Suburb : Entity
{
    public Suburb(int id, string name, string postcode)
    {
        Id = id;
        Name = name;
        Postcode = postcode;
    }

    public string Name { get; private set; }
    public string Postcode { get; private set; }
}