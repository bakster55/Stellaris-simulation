using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris_simulation
{
    [DebuggerDisplay("{Name}")]
    public class Building
    {
        public string Name { get; set; }

        public Dictionary<ResourceType, Production> ProductionByResourceType { get; set; }

        public Dictionary<Job, int> CountOfJobsByJob { get; set; }

        public Dictionary<Job, Production> JobMultipliers { get; set; }

        public static Building PlanetaryCapital { get; set; }
        public static Building SystemCapitalComplex { get; set; }
        public static Building CivilianIndustries { get; set; }
        public static Building CivilianFabricators { get; set; }
        public static Building CivilianRepliComplexes { get; set; }
        public static Building AdministrativeOffice { get; set; }
        public static Building AdministrativePark { get; set; }
        public static Building AlloyFoundries { get; set; }
        public static Building AlloyMegaForges { get; set; }
        public static Building AlloyNanoPlants { get; set; }
        public static Building SyntheticCrystalPlants { get; set; }
        public static Building ChemicalPlants { get; set; }
        public static Building ExoticGasRefineries { get; set; }
        public static Building ResearchLabs { get; set; }
        public static Building ResearchComplexes { get; set; }
        public static Building AdvancedResearchComplexes { get; set; }
        public static Building MinistryOfProduction { get; set; }

        public Building(
            string name,
            Dictionary<ResourceType, Production> productionByResourceType,
            Dictionary<Job, int> jobs,
            Dictionary<Job, Production> jobMultiplicators = null)
        {
            Name = name;
            ProductionByResourceType = productionByResourceType;
            CountOfJobsByJob = jobs;
            JobMultipliers = jobMultiplicators;
        }

        static Building()
        {
            Dictionary<ResourceType, Production> productionByResourceType;
            Dictionary<Job, int> jobs;
            Dictionary<Job, Production> jobMultiplicators;

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -8) },
                { ResourceType.Housing, new Production(ProductionType.Production, 9) },
                { ResourceType.Amenities, new Production(ProductionType.Production, 8) }
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Enforcer, 2 },
                { Job.Administrator, 3 },
            };
            PlanetaryCapital = new Building("Planetary Capital", productionByResourceType, jobs);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -10) },
                { ResourceType.Housing, new Production(ProductionType.Production, 13) },
                { ResourceType.Amenities, new Production(ProductionType.Production, 12) }
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Enforcer, 3 },
                { Job.Administrator, 4 },
            };
            SystemCapitalComplex = new Building("System Capital-Complex", productionByResourceType, jobs);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -2) },
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Artisan, 2 },
            };
            CivilianFabricators = new Building("Civilian Industries", productionByResourceType, jobs);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -5) },
                { ResourceType.RareCrystals, new Production(ProductionType.Upkeep, -1) }
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Artisan, 5 },
            };
            CivilianFabricators = new Building("Civilian Fabricators", productionByResourceType, jobs);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -8) },
                { ResourceType.RareCrystals, new Production(ProductionType.Upkeep, -2) }
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Artisan, 8 },
            };
            CivilianRepliComplexes = new Building("Civilian Repli-Complexes", productionByResourceType, jobs);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 8 },
            //    { ResourceType.Energy, -8 },
            //    { ResourceType.Minerals, -48 },
            //    { ResourceType.ConsumerGoods, 48 },
            //    { ResourceType.RareCrystals, -2 }
            //};
            //AdministrativeOffice = new Building("Administrative Office", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //AdministrativePark = new Building("Administrative Park", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //AlloyFoundries = new Building("Alloy foundries", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //AlloyMegaForges = new Building("Alloy mega-forges", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //AlloyNanoPlants = new Building("Alloy nano-plants", productionByResourceType);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -3) },
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Translucer, 1 },
            };
            SyntheticCrystalPlants = new Building("Synthetic Crystal Plants", productionByResourceType, jobs);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //ChemicalPlants = new Building("Chemical Plants", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //ExoticGasRefineries = new Building("Exotic Gas Refineries", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //ResearchLabs = new Building("Research Labs", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //ResearchComplexes = new Building("Research Complexes", productionByResourceType);

            //productionByResourceType = new Dictionary<ResourceType, int>()
            //{
            //    { ResourceType.Jobs, 2 },
            //    { ResourceType.Energy, -2 },
            //    { ResourceType.Minerals, -12 },
            //    { ResourceType.ConsumerGoods, 12 }
            //};
            //AdvancedResearchComplexes = new Building("Advanced Research Complexes", productionByResourceType);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Energy, new Production(ProductionType.Upkeep, -5) },
                { ResourceType.VolatileMotes, new Production(ProductionType.Upkeep, -1) },
            };
            jobs = new Dictionary<Job, int>
            {
                { Job.Administrator, 1 },
            };
            jobMultiplicators = new Dictionary<Job, Production>
            {
                { Job.Artisan, new Production(ProductionType.Production, 1.15m) },
            };
            MinistryOfProduction = new Building("Ministry Of Production", productionByResourceType, jobs, jobMultiplicators);
        }
    }
}
