using AutoMapper;
using BWE.Domain.DBModel;
using BWE.Domain.Model;
using BWE.Domain.ViewModel;

namespace BWE.Domain.Mapping
{
    public class ApplicationUserMapping : Profile
    {
        public ApplicationUserMapping()
        {
            CreateMap<RegisterModel,ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u=>u.PasswordHash, opt=> opt.MapFrom(x=> x.Password))
                .ReverseMap();

            CreateMap<ApplicationUser, UserViewModel>()
                //.ForMember(u => u.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(u => u.Name, opt => opt.MapFrom(x => x.FirstName +" "+x.LastName))
                //.ForMember(u => u.Email, opt => opt.MapFrom(x => x.Email))
                //.ForMember(u => u.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
                //.ForMember(u => u.UserRoles, opt => opt.MapFrom(x => x.PhoneNumber))
                .ReverseMap();

            CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
