using AutoMapper;
using MediaDatabaseCreator.Model.DTO;
using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Profiles
{
    public class CharacterProfile : Profile
    {
            public CharacterProfile()
            {
                CreateMap<Character, CharacterDTO>();
            }
    }
}
