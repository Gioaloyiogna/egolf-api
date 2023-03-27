namespace GolfWebApi.Models;

public class Hole
{
    public int Id { get; set; } 
    
    public int HoleNumber { get; set; }
    
    public int Par { get; set; }
    
    public int Yardage { get; set; }
    
    public int Handicap { get; set; }
     
    public int CourseId { get; set; } 
}
