using AutoMapper;
using MediaDatabaseCreator.Model.DTO;
using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Profiles
{
    public class CharacterProfile : Profile
    {
            public CharacterProfile()
            {
            CreateMap<Character, CharacterDTO>()
            .ForMember(DTO => DTO.FullName, opt => opt.MapFrom(c => c.FullName))
            .ForMember(DTO => DTO.Alias, opt => opt.MapFrom(c => c.Alias))
            .ForMember(DTO => DTO.Gender, opt => opt.MapFrom(c => c.Gender))
            .ForMember(DTO => DTO.PictureUrl, opt => opt.MapFrom(c => c.PictureUrl))
            .ForMember(DTO => DTO.Movies, opt => opt.MapFrom(c => c.Movies.Select(c => c.MovieId).ToArray()));
        }
    }
}
