using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Projects.Commands.UpdateProject;

namespace ProjectDash.WebAPI.Models
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Performer { get; set; }
        public string? Customer { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? Priority { get; set; }
        public Guid? ProjectLeaderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(updateProjectCommand => updateProjectCommand .Id,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.Id))
                .ForMember(updateProjectCommand => updateProjectCommand .Name,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.Name))
                .ForMember(updateProjectCommand => updateProjectCommand .Performer,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.Performer))
                .ForMember(updateProjectCommand => updateProjectCommand .Customer,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.Customer))
                .ForMember(updateProjectCommand => updateProjectCommand .StartDate,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.StartDate))
                .ForMember(updateProjectCommand => updateProjectCommand .EndDate,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.EndDate))
                .ForMember(updateProjectCommand => updateProjectCommand .Priority,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.Priority))
                .ForMember(updateProjectCommand => updateProjectCommand .ProjectLeaderId,
                    opt => opt.MapFrom(updateProjectDto => updateProjectDto.ProjectLeaderId));
        }
    }
}
