using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Employees.Commands.UpdateEmployee;

namespace ProjectDash.Web.Models
{
    public class UpdateEmployeeDto : IMapWith<UpdateEmployeeCommand>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                .ForMember(updateEmployeeCommand => updateEmployeeCommand.Id,
                    opt => opt.MapFrom(updateEmployeeDto => updateEmployeeDto.Id))
                .ForMember(updateEmployeeCommand => updateEmployeeCommand.Name,
                    opt => opt.MapFrom(updateEmployeeDto => updateEmployeeDto.Name))
                .ForMember(updateEmployeeCommand => updateEmployeeCommand.Surname,
                    opt => opt.MapFrom(updateEmployeeDto => updateEmployeeDto.Surname))
                .ForMember(updateEmployeeCommand => updateEmployeeCommand.Patronymic,
                    opt => opt.MapFrom(updateEmployeeDto => updateEmployeeDto.Patronymic))
                .ForMember(updateEmployeeCommand => updateEmployeeCommand.Email,
                    opt => opt.MapFrom(updateEmployeeDto => updateEmployeeDto.Email)); ;
        }
    }
}
