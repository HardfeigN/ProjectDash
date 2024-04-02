using AutoMapper;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails
{
    public class ProjectDocumentDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDocument, ProjectDocumentDetailsVm>()
                .ForMember(projectDocumentVm => projectDocumentVm.Id,
                    opt => opt.MapFrom(projectDocument => projectDocument.Id))
                .ForMember(projectDocumentVm => projectDocumentVm.Name,
                    opt => opt.MapFrom(projectDocument => projectDocument.Name))
                .ForMember(projectDocumentVm => projectDocumentVm.Id,
                    opt => opt.MapFrom(projectDocumentVm => projectDocumentVm.ProjectId));
        }
    }
}
