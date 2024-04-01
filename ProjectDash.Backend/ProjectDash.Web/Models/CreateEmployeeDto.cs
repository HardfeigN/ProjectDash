using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Employees.Commands.CreateEmployee;

namespace ProjectDash.Web.Models
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.Name,
                    opt => opt.MapFrom(employeeDto => employeeDto.Name))
                .ForMember(employeeCommand => employeeCommand.Surname,
                    opt => opt.MapFrom(employeeDto => employeeDto.Surname))
                .ForMember(employeeCommand => employeeCommand.Patronymic,
                    opt => opt.MapFrom(employeeDto => employeeDto.Patronymic))
                .ForMember(employeeCommand => employeeCommand.Email,
                    opt => opt.MapFrom(employeeDto => employeeDto.Email));
        }
    }
}
