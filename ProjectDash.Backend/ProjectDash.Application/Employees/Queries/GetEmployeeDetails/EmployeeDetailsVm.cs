using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeVm => employeeVm.Id,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeVm => employeeVm.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeVm => employeeVm.Surname,
                    opt => opt.MapFrom(employee => employee.Surname))
                .ForMember(employeeVm => employeeVm.Patronymic,
                    opt => opt.MapFrom(employee => employee.Patronymic))
                .ForMember(employeeVm => employeeVm.Email,
                    opt => opt.MapFrom(employee => employee.Email));
        }
    }
}
