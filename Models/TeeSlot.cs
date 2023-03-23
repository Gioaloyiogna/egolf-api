using System.Media;
using System.Runtime.Serialization;

namespace GolfWebApi.Models
{
    public class TeeSlot
    {
        public int Id { get; set; }
        public DateTime Teetime { get; set; } 
        
        public string Player1Type{ get; set; } = "No Player 1 Type";

        public string Player1 { get; set; } = "No Player 1";
        
        public string Player1Email { get; set; } = "No Player 1 Email";
        
        public string Player2Type { get; set; } = "No Player 2 Type";
        
        public string Player2 { get; set; } = "No Player 2";
        
        public string Player2Email { get; set; } = "No Player 2 Email";
        
        public string Player3Type { get; set; } = "No Player 3 Type";
        
        public string Player3 { get; set; } = "No Player 3";
        
        public string Player3Email { get; set; } = "No Player 3 Email";
        
        public string Player4Type { get; set; } = "No Player 4";
        
        public string Player4 { get; set; } = "No Player 4";
        
        public string Player4Email { get; set; } = "No Player 4 Email";

        public bool? IsAvailable { get; set; }

        public int? CaddyId { get; set; }
    }
}
