namespace GolfWebApi.Models;

public class Course 
{
  public int Id { get; set; }
  public int Hole { get; set; }
  public int Par { get; set; }
  public int Yardage { get; set; }
  public int Handicap { get; set; }
}