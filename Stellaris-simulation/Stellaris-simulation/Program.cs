using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Building> buildings = new List<Building>
            {
                Building.SystemCapitalComplex,
                Building.CivilianRepliComplexes,
                Building.CivilianRepliComplexes,
                Building.CivilianRepliComplexes,
                Building.CivilianRepliComplexes,
                Building.CivilianRepliComplexes,
                Building.CivilianRepliComplexes,
                Building.SyntheticCrystalPlants,
                Building.SyntheticCrystalPlants,
                Building.SyntheticCrystalPlants,
                Building.SyntheticCrystalPlants,
                Building.SyntheticCrystalPlants,
                Building.SyntheticCrystalPlants,
                Building.MinistryOfProduction,
                //Building.SystemCapitalComplex,
                //Building.SystemCapitalComplex,
            };
            Planet planet = new Planet(buildings, 16, PlanetSpecialization.IndustrialWorld);

            Dictionary<ResourceType, Production> total = planet.GetTotal();
            int totalJobs = planet.GetTotalJobs();
        }
    }
}
