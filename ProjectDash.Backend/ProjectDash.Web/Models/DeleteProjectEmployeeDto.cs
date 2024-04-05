using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.ProjectEmployees.Commands.DeleteProjectEmployee;

namespace ProjectDash.Web.Models
{
    public class DeleteProjectEmployeeDto : IMapWith<DeleteProjectEmployeeCommand>
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<DeleteProjectEmployeeDto, DeleteProjectEmployeeCommand>()
                .ForMember(projectEmployeeDto => projectEmployeeDto.ProjectId,
                    opt => opt.MapFrom(projectEmployee => projectEmployee.ProjectId))
                .ForMember(projectEmployeeDto => projectEmployeeDto.EmployeeId,
                    opt => opt.MapFrom(projectEmployee => projectEmployee.EmployeeId));
        }
    }
}
