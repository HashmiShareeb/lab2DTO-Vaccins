namespace lab2DTO.Services;
public interface IVaccinationService
{
    //add registration
    VaccinRegistration AddRegistration(VaccinRegistration registration);
    //get locations
    List<VaccinationLocation> GetLocations();
    //get registrations
    List<VaccinRegistration> GetRegistrations();
    //get vaccintypes
    List<VaccinType> GetVaccins();

}
public class VaccinationService : IVaccinationService
{
    private readonly IVaccinationRegistrationRepository _vaccinationRegistrationRepository;
    private readonly IVaccinTypeRepository _vaccinTypeRepository;
    private readonly IVaccinationLocationRepository _vaccinationLocationRepository;

    //constructor all interfaces opvragen
    public VaccinationService(IVaccinationRegistrationRepository vaccinationRegistrationRepository, IVaccinTypeRepository vaccinTypeRepository, IVaccinationLocationRepository vaccinationLocationRepository)
    {
        _vaccinationRegistrationRepository = vaccinationRegistrationRepository;
        _vaccinTypeRepository = vaccinTypeRepository;
        _vaccinationLocationRepository = vaccinationLocationRepository;
    }

    public VaccinRegistration AddRegistration(VaccinRegistration registration)
    {
        ArgumentNullException.ThrowIfNull(registration); //null expetion if null
        _vaccinationRegistrationRepository.AddRegistration(registration);
        return registration;
    }

    public List<VaccinationLocation> GetLocations()
    {
        return _vaccinationLocationRepository.GetLocations();
    }

    public List<VaccinRegistration> GetRegistrations()
    {
        return _vaccinationRegistrationRepository.GetRegistrations();
    }

    public List<VaccinType> GetVaccins()
    {
        return _vaccinTypeRepository.GetVaccinTypes();
    }
}

