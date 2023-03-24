namespace GolfWebApi.Models;

public class Course 
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int NumberOfHoles { get; set; } 
  
  public ICollection<Hole> Holes { get; set; } = new List<Hole>();
}