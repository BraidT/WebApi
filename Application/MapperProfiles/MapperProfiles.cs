using Application.Commands.Events;
using Application.Commands.Participants;
using Application.Responses;
using AutoMapper;
using Core.Entities;

namespace Application.MapperProfiles
{
    public class MapperProfiles : Profile {
        public MapperProfiles() {

            CreateMap<CreateBusinessParticipantCommand, BusinessParticipant>().ReverseMap();
            CreateMap<BusinessParticipant, BusinessParticipantResponse>();

            CreateMap<CreatePrivateParticipantCommand, PrivateParticipantResponse>().ReverseMap();
            CreateMap<PrivateParticipant, PrivateParticipantResponse>();

            CreateMap<Event, EventResponse>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<PrivateParticipant, CreatePrivateParticipantCommand>().ReverseMap();
            CreateMap<PrivateParticipant, UpdatePrivateParticipantCommand>().ReverseMap();
            CreateMap<BusinessParticipant, CreateBusinessParticipantCommand>().ReverseMap();
            CreateMap<BusinessParticipant, UpdateBusinessParticipantCommand>().ReverseMap();

            CreateMap<EventPrivateParticipant, CreateEventPrivateParticipantCommand>().ReverseMap();
            CreateMap<EventBusinessParticipant, CreateEventBusinessParticipantCommand>().ReverseMap();

            CreateMap<EventBusinessParticipant, BusinessParticipant>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); ;
            CreateMap<EventPrivateParticipant, PrivateParticipant>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EventBusinessParticipant, BusinessParticipantResponse>()
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.ParticipantCount))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BusinessParticipant.Name))
                .ForMember(dest => dest.RegistryCode, opt => opt.MapFrom(src => src.BusinessParticipant.RegistryCode));

            CreateMap<EventBusinessParticipant, EventBusinessParticipantResponse>()
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.ParticipantCount))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BusinessParticipant.Name))
                .ForMember(dest => dest.RegistryCode, opt => opt.MapFrom(src => src.BusinessParticipant.RegistryCode));

            CreateMap<EventPrivateParticipant, PrivateParticipantResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.PrivateParticipant.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.PrivateParticipant.LastName))
                .ForMember(dest => dest.PersonalCode, opt => opt.MapFrom(src => src.PrivateParticipant.PersonalCode));

            CreateMap<EventPrivateParticipant, EventPrivateParticipantResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.PrivateParticipant.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.PrivateParticipant.LastName))
                .ForMember(dest => dest.PersonalCode, opt => opt.MapFrom(src => src.PrivateParticipant.PersonalCode));

            
        }
    }
}
