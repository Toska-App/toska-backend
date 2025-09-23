using AutoMapper;
using Toska.DTOs.User;
using Toska.Models.User;

namespace Toska.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            //Map from User -> UserDto
            CreateMap<User, UserDto>();


            //Map from CreateUserDto -> User
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PublicId, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        }
    }
}

