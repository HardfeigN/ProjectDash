using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Projects.Commands.UpdateProject;

namespace ProjectDash.WebAPI.Models
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Id,
                    opt => opt.MapFrom(projectDto => projectDto.Id))
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectDto => projectDto.Name))
                .ForMember(projectCommand => projectCommand.Performer,
                    opt => opt.MapFrom(projectDto => projectDto.Performer))
                .ForMember(projectCommand => projectCommand.Customer,
                    opt => opt.MapFrom(projectDto => projectDto.Customer))
                .ForMember(projectCommand => projectCommand.CreationDate,
                    opt => opt.MapFrom(projectDto => projectDto.CreationDate))
                .ForMember(projectCommand => projectCommand.CreationDate,
                    opt => opt.MapFrom(projectDto => projectDto.CreationDate))
                .ForMember(projectCommand => projectCommand.Priority,
                    opt => opt.MapFrom(projectDto => projectDto.Priority))
                .ForMember(projectCommand => projectCommand.ProjectLeaderId,
                    opt => opt.MapFrom(projectDto => projectDto.ProjectLeaderId));
        }

    }
}
