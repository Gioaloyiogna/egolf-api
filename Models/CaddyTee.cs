namespace GolfWebApi.Models
{
    public class CaddyTee
    {

        public int Id { get; set; }
       public  int caddyId { get; set; }
        public string? playerId { get; set; }
        public string? Code { get; set; }
       public  string? teeTime { get; set; }
       public  string? caddyName { get; set; }
       public  string? caddyEmail { get; set; }
       public  string ? caddyPhone { get; set; }
       public  string? caddyGender { get; set; }
          

    }
}
