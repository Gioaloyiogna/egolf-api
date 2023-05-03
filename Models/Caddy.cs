using Microsoft.AspNetCore.Mvc;

namespace GolfWebApi.Models
{
    public class Caddy
    {
        public int Id { get; set; }
        
        public string? Picture { get; set; } = string.Empty;
        
        public string Code { get; set; } = string.Empty;
        
        public string Fname { get; set; } = string.Empty;
        
        public string Lname { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
        public string Gender { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;

        public ICollection<TeeSlot>? TeeSlots { get; set; }

       
    }
}
