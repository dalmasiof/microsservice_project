using AutoMapper;
using UserService.Model;

namespace UserService
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserData, UserVM>().ReverseMap();
        }
    }
}
