using GolfWebApi.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GolfWebApi.Models;

public class GameType
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; } = string.Empty;

    public ICollection<GameSchedule>? GameSchedules { get; set; }
}