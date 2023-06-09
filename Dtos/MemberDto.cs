﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GolfWebApi.Dtos
{
    public class MemberDto
    {
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? MembershipId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public string? PlayerHandicap { get; set; }
        public string? Ggaid { get; set; }
        public string? Status { get; set; } = "Inactive";
        public string? Picture { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
