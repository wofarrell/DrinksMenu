
namespace Models.DrinksFiltered;


public record class DrinkName
{
     public string? strDrink { get; set; }
     public string? idDrink { get; set; }
};

public class FilteredDrinkList
{
    public List<DrinkName>? drinks { get; set; }
};
