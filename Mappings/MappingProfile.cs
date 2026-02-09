using AutoMapper;
using projetNet.Models;
using projetNet.DTOs.Vehicle;

namespace projetNet.Mappings;

/// <summary>
/// AutoMapper profile for mapping between domain models and DTOs
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Vehicle mappings
        CreateMap<CreateVehicleRequest, Vehicle>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OwnerId, opt => opt.Ignore()); // Set by service
        
        CreateMap<UpdateVehicleRequest, Vehicle>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Vin, opt => opt.Ignore()) // VIN cannot be changed
            .ForMember(dest => dest.OwnerId, opt => opt.Ignore());
        
        CreateMap<Vehicle, VehicleResponse>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price ?? 0))
            .ForMember(dest => dest.Mileage, opt => opt.MapFrom(src => src.Mileage ?? 0))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model ?? string.Empty))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location ?? string.Empty));
        
   
    }
}
