using System.Text.Json.Serialization;

namespace Models.CategoryNames;

public record class CatName
{
     public string? strCategory { get; set; }
};

public record class CatList
{
    public List<CatName>? drinks { get; set; }
};