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
                .ForMember(deletePECommand => deletePECommand.ProjectId,
                    opt => opt.MapFrom(deletePEDto => deletePEDto.ProjectId))
                .ForMember(deletePECommand => deletePECommand.EmployeeId,
                    opt => opt.MapFrom(deletePEDto => deletePEDto.EmployeeId));
        }
    }
}
