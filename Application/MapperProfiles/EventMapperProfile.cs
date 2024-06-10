using Application.Commands.Events;
using Application.Responses;
using AutoMapper;
using Core.Entities;

namespace Application.MapperProfiles {
    public class EventMapperProfile : Profile {
        public EventMapperProfile() {
            CreateMap<Event, EventResponse>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
