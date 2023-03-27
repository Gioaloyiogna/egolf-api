namespace GolfWebApi.Models;

public class Fee
{
  public int Id { get; set; }
  public string? Code { get; set; }
  public string? Name { get; set; }
  public string? Amount { get; set; }
  public string? Frequency { get; set; }
}