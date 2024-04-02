﻿using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList
{
    public class ProjectDocumentLookupDto : IMapWith<ProjectDocument>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectDocument, ProjectDocumentLookupDto>()
                .ForMember(projectDocumentVm => projectDocumentVm.Id,
                    opt => opt.MapFrom(projectDocument => projectDocument.Id))
                .ForMember(projectDocumentVm => projectDocumentVm.Name,
                    opt => opt.MapFrom(projectDocument => projectDocument.Name))
                .ForMember(projectDocumentVm => projectDocumentVm.Id,
                    opt => opt.MapFrom(projectDocumentVm => projectDocumentVm.ProjectId));
        }
    }
}
