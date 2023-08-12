namespace lab2DTO.Repositories;
public interface IVaccinationRegistrationRepository
{
    //get registrations
    List<VaccinRegistration> GetRegistrations();

    //add registration
    void AddRegistration(VaccinRegistration registration);
}
public class VaccinationRegistrationRepository : IVaccinationRegistrationRepository
{
    private static List<VaccinRegistration> _registrations = new List<VaccinRegistration>();

    public VaccinationRegistrationRepository()
    {
        //zonder CSV file -> in configuration folder kijken
        if (!(_registrations.Any()))
        {
            _registrations.Add(new VaccinRegistration()
            {
                VaccinatinRegistrationId = Guid.Parse("0be0d145-0591-426b-83e8-7c3ca3e3b518"),
                Name = "Hashmi",
                FirstName = "Shareeb",
                EMail = "sh@hotmail.com",
                YearOfBirth = 1999,
                VaccinationDate = "2021-10-10",
                VaccinTypeId = Guid.Parse("2319af77-eb47-4515-8076-9880ae2a5e53"),
                VaccinationLocationId = Guid.Parse("144f017c-d7d6-41b4-aa1e-d076454dbb25"),

            });
            _registrations.Add(new VaccinRegistration()
            {
                VaccinatinRegistrationId = Guid.Parse("d2a79300-cdad-44b1-96bd-560361d04cf1"),
                Name = "De Preester",
                FirstName = "Dieter",
                EMail = "dt@hotmail.com",
                YearOfBirth = 1979,
                VaccinationDate = "2021-12-10",
                VaccinTypeId = Guid.Parse("2319af77-eb47-4515-8076-9880ae2a5e53"),
                VaccinationLocationId = Guid.Parse("fd51fe50-eaaf-41e0-93c2-85b3da87acb6"),

            });



        }


    }

    // Void -> method that does not return a value
    public void AddRegistration(VaccinRegistration registration)
    {
        ArgumentNullException.ThrowIfNull(registration);
        _registrations.Add(registration);
    }

    public List<VaccinRegistration> GetRegistrations()
    {
        return _registrations.ToList<VaccinRegistration>();
    }
}





