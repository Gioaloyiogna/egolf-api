namespace GolfWebApi.Models
{
    public class TeeSlot
    {
        public int Id { get; set; }
        public int? memberId { get; set; }
        public string? memberCode { get; set; }
        public string? playerType { get; set; }
        public string? playerEmail { get; set; }
        public string? teeTime { get; set; }
        public string? playerName { get; set; }
        public string? availabilityStatus { get; set; }
        public int? caddyId { get; set; }

        public static implicit operator TeeSlot(List<TeeSlot> v)
        {
            throw new NotImplementedException();
        }
    }
}
