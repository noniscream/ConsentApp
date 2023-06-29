using AutoMapper;
using CommonAPI.DTOs;
using CommonAPI.Entities;
using CommonAPI.Extensions;

namespace CommonAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt
                    .MapFrom(src => src.Photos
                    .FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(dest=>dest.Age, opt=>opt.MapFrom(src=>src.DateOfBirth.CalcuateAge()));
            CreateMap<Photo,PhotoDto>();   
        }
    }
}