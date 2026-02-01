namespace ClinicDB.Models;

public class Ingredient
{
	public int IngredientId { get; set; }
	public string Name { get; set; } = null!;
	public DateTime CreatedAt { get; set; }
}
