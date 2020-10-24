using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris_simulation
{
    public class PlanetSpecialization
    {
        public Dictionary<Job, Production> JobProductionMultipliers { get; set; }

        public static PlanetSpecialization IndustrialWorld { get; set; }

        public PlanetSpecialization(Dictionary<Job, Production> jobProductionMultipliers)
        {
            JobProductionMultipliers = jobProductionMultipliers;
        }

        static PlanetSpecialization()
        {
            IndustrialWorld = new PlanetSpecialization(new Dictionary<Job, Production> { { Job.Artisan, new Production(ProductionType.Upkeep, 0.8m) } });
        }
    }
}
