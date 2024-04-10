using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Employees.Queries.GetEmployeeList;

namespace ProjectDash.Web.Models
{
    public class GetEmployeeListDto : IMapWith<GetEmployeeListQuery>
    {
        public Guid? ProjectId { get; set; }
        public string? TextField { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetEmployeeListDto, GetEmployeeListQuery>()
                .ForMember(getEmployeeListQuery => getEmployeeListQuery.ProjectId,
                    opt => opt.MapFrom(getEmployeeListDto => getEmployeeListDto.ProjectId))
                .ForMember(getEmployeeListQuery => getEmployeeListQuery.TextField,
                    opt => opt.MapFrom(getEmployeeListDto => getEmployeeListDto.TextField))
                .ForMember(getEmployeeListQuery => getEmployeeListQuery.Name,
                    opt => opt.MapFrom(getEmployeeListDto => getEmployeeListDto.Name))
                .ForMember(getEmployeeListQuery => getEmployeeListQuery.Surname,
                    opt => opt.MapFrom(getEmployeeListDto => getEmployeeListDto.Surname))
                .ForMember(getEmployeeListQuery => getEmployeeListQuery.Patronymic,
                    opt => opt.MapFrom(getEmployeeListDto => getEmployeeListDto.Patronymic))
                .ForMember(getEmployeeListQuery => getEmployeeListQuery.Email,
                    opt => opt.MapFrom(getEmployeeListDto => getEmployeeListDto.Email));
        }
    }
}
