namespace ClinicDB.Models;

public class Recipe
{
    public int RecipeId { get; set; }
    public string Title { get; set; } = null!;
    public int PrepMinutes { get; set; }
    public int CookMinutes { get; set; }
    public int Servings { get; set; }
    public DateTime CreatedAt { get; set; }
}
