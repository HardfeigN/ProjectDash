using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList
{
    public class ProjectDocumentLookupDto : IMapWith<ProjectDocument>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDocument, ProjectDocumentLookupDto>()
                .ForMember(projectDocumentDto => projectDocumentDto.Id,
                    opt => opt.MapFrom(projectDocument => projectDocument.Id))
                .ForMember(projectDocumentDto => projectDocumentDto.Name,
                    opt => opt.MapFrom(projectDocument => projectDocument.Name))
                .ForMember(projectDocumentDto => projectDocumentDto.ProjectId,
                    opt => opt.MapFrom(projectDocument => projectDocument.ProjectId));
        }
    }
}
