﻿using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(projectDto => projectDto.Performer,
                    opt => opt.MapFrom(project => project.Performer))
                .ForMember(projectDto => projectDto.Customer,
                    opt => opt.MapFrom(project => project.Customer))
                .ForMember(projectDto => projectDto.StartDate,
                    opt => opt.MapFrom(project => project.StartDate))
                .ForMember(projectDto => projectDto.EndDate,
                    opt => opt.MapFrom(project => project.EndDate))
                .ForMember(projectDto => projectDto.Priority,
                    opt => opt.MapFrom(project => project.Priority))
                .ForMember(projectDto => projectDto.ProjectLeaderId,
                    opt => opt.MapFrom(project => project.ProjectLeaderId));
        }
    }
}
