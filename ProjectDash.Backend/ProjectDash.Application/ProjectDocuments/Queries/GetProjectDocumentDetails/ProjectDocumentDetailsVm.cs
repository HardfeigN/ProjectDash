using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails
{
    public class ProjectDocumentDetailsVm : IMapWith<ProjectDocument>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public Guid ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDocument, ProjectDocumentDetailsVm>()
                .ForMember(projectDocumentDetailsVm => projectDocumentDetailsVm.Id,
                    opt => opt.MapFrom(projectDocument => projectDocument.Id))
                .ForMember(projectDocumentDetailsVm => projectDocumentDetailsVm.Name,
                    opt => opt.MapFrom(projectDocument => projectDocument.Name))
                .ForMember(projectDocumentDetailsVm => projectDocumentDetailsVm.ProjectId,
                    opt => opt.MapFrom(projectDocument => projectDocument.ProjectId))
                .ForMember(projectDocumentDetailsVm => projectDocumentDetailsVm.Extension,
                    opt => opt.MapFrom(projectDocument => projectDocument.Extension));
        }
    }
}
