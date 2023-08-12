using System;

namespace lab2DTO.DTO.Profiles;
//Automapper is based on the concept of a Profile. This profile will determine which objects Automapper should map. 
public class DTOProfile : Profile
{
    public DTOProfile()
    {
        CreateMap<VaccinRegistration, VaccinRegistrationDTO>()
        .ForMember(dest => dest.VaccinName, opt => opt.MapFrom<VaccinResolver>())
        .ForMember(dest => dest.Location, opt => opt.MapFrom<VaccinLocationResolver>());
    }

}
//zoekt in de lijst achter de juiste locatie an vaccin 
public class VaccinLocationResolver : IValueResolver<VaccinRegistration, VaccinRegistrationDTO, string>
{   //implenteerd de interface IValueResolver; waar je de mapper wilt schrijven en de terugkeer type 
    public string Resolve(VaccinRegistration source, VaccinRegistrationDTO destination, string dest, ResolutionContext context)
    {
        List<VaccinationLocation> locations = context.Items["locations"] as List<VaccinationLocation>;
        return locations.Where(l => l.VaccinationLocationId == source.VaccinationLocationId).Single().Name;
    }
}

public class VaccinResolver : IValueResolver<VaccinRegistration, VaccinRegistrationDTO, string>
{
    public string Resolve(VaccinRegistration source, VaccinRegistrationDTO destination, string dest, ResolutionContext context)
    {
        List<VaccinType> vaccins = context.Items["vaccins"] as List<VaccinType>;
        return vaccins.Where(l => l.VaccinTypeId == source.VaccinTypeId).Single().Name;
    }
}

//in een profile bepaal je de mapping van de properties van je model naar je DTO


