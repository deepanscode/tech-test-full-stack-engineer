using TradieApp.Domain.Common;

namespace TradieApp.Domain.Entities;

public record Contact(string Name, string Phone, string Email): ValueObject;
