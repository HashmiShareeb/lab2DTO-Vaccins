using System;

namespace lab2DTO.Repositories;

public interface IVaccinTypeRepository
{
    List<VaccinType> GetVaccinTypes();
}
public class VaccinTypeRepository : IVaccinTypeRepository
{
    //data hardcoded zonder database
    //1: maak static list aan 
    private static List<VaccinType> _vaccinTypes = new List<VaccinType>();

    //2: vul de list met data
    public VaccinTypeRepository()
    {
        if (!(_vaccinTypes.Any()))
        {
            _vaccinTypes.Add(new VaccinType()
            {
                VaccinTypeId = Guid.Parse("2319af77-eb47-4515-8076-9880ae2a5e53"),
                Name = "Pfizer",
            });
            _vaccinTypes.Add(new VaccinType()
            {
                VaccinTypeId = Guid.Parse("a19b13be-c985-4da2-9e27-9cd2a99528a0"),
                Name = "Moderna",
            });
        }
    }

    public List<VaccinType> GetVaccinTypes()
    {
        return _vaccinTypes.ToList<VaccinType>();
    }
}



