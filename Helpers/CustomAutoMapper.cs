using AutoMapper;
using GolfWebApi.Dtos;
using GolfWebApi.Models;

namespace GolfWebApi.Helpers
{
    public class CustomAutoMapper : Profile
    {
        public CustomAutoMapper()
        {

            CreateMap<MemberDto, Member>().ReverseMap();


        }
    }
}
