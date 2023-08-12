using System;

namespace lab2DTO.Repositories
{
    public interface IVaccinationLocationRepository
    {
        List<VaccinationLocation> GetLocations();
    }

    public class VaccinationLocationRepository : IVaccinationLocationRepository
    {
        //data hardcoded zonder database
        //1: maak static list aan 
        private static List<VaccinationLocation> _locations = new List<VaccinationLocation>();

        //2: vul de list met data
        public VaccinationLocationRepository()
        {
            if (!(_locations.Any()))
            {
                _locations.Add(new VaccinationLocation()
                {
                    VaccinationLocationId = Guid.Parse("144f017c-d7d6-41b4-aa1e-d076454dbb25"),
                    Name = "Kortijk Xpo",
                });
                _locations.Add(new VaccinationLocation()
                {
                    VaccinationLocationId = Guid.Parse("fd51fe50-eaaf-41e0-93c2-85b3da87acb6"),
                    Name = "Gent Flanders Expo",
                });
            }
        }

        public List<VaccinationLocation> GetLocations()
        {
            return _locations.ToList<VaccinationLocation>();
        }
    }


}
