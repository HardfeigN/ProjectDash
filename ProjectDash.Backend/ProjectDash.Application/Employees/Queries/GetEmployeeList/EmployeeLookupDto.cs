using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeList
{
    public class EmployeeLookupDto : IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeLookupDto>()
                .ForMember(employeeDto => employeeDto.Id,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeDto => employeeDto.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeDto => employeeDto.Surname,
                    opt => opt.MapFrom(employee => employee.Surname))
                .ForMember(employeeDto => employeeDto.Patronymic,
                    opt => opt.MapFrom(employee => employee.Patronymic))
                .ForMember(employeeDto => employeeDto.Email,
                    opt => opt.MapFrom(employee => employee.Email));
        }
    }
}
