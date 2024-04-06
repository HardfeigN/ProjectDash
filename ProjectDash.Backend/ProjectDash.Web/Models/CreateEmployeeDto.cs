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
                .ForMember(createEmployeeCommand => createEmployeeCommand.Name,
                    opt => opt.MapFrom(createEmployeeDto => createEmployeeDto.Name))
                .ForMember(createEmployeeCommand => createEmployeeCommand.Surname,
                    opt => opt.MapFrom(createEmployeeDto => createEmployeeDto.Surname))
                .ForMember(createEmployeeCommand => createEmployeeCommand.Patronymic,
                    opt => opt.MapFrom(createEmployeeDto => createEmployeeDto.Patronymic))
                .ForMember(createEmployeeCommand => createEmployeeCommand.Email,
                    opt => opt.MapFrom(createEmployeeDto => createEmployeeDto.Email));
        }
    }
}
