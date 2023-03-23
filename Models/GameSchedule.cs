using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfWebApi.Models;

public class GameSchedule
{
    [Required(ErrorMessage = "Game Id is required")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Game Title is required")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
    public string? Subject { get; set; }
    
    [Required(ErrorMessage = "Game StartDate is required")]
    public DateTime StartTime { get; set; }
    
    [Required(ErrorMessage = "Game EndDate is required")]
    public DateTime EndTime { get; set; }
    
    [Required(ErrorMessage = "Game Description is required")]
    [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")]
    public string? Description { get; set; }
     
    public long GameTypeId { get; set; }  
}