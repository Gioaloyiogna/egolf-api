global using Microsoft.EntityFrameworkCore;
using GolfWebApi.Models;

namespace GolfWebApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<GameType> GameTypes { get; set; }
    public DbSet<GameSchedule> GameSchedules { get; set; }
    
    public DbSet<Course> Courses { get; set; }
} 