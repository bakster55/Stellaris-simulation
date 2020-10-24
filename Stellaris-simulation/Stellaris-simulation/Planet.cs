using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris_simulation
{
    public class Planet
    {
        public List<Building> Buildings { get; set; }

        public int Size { get; set; }

        public PlanetSpecialization PlanetSpecialization { get; set; }

        public Planet(List<Building> buildings, int size, PlanetSpecialization planetSpecialization)
        {
            Buildings = buildings;
            Size = size;
            PlanetSpecialization = planetSpecialization;
        }

        public Dictionary<ResourceType, Production> GetTotal()
        {
            Dictionary<Job, Dictionary<ResourceType, Production>> productionByResourceTypeByJob = new Dictionary<Job, Dictionary<ResourceType, Production>>();

            // Fill production by job
            foreach (Building building in Buildings)
            {
                foreach (var jobCount in building.CountOfJobsByJob)
                {
                    Job job = jobCount.Key;
                    int countOfJob = jobCount.Value;

                    foreach (var jobResourceTypeProduction in job.ProductionByResourceType)
                    {
                        ResourceType resourceType = jobResourceTypeProduction.Key;
                        Production production = jobResourceTypeProduction.Value;

                        Production totalProduction = production * countOfJob;

                        if (!productionByResourceTypeByJob.ContainsKey(job))
                        {
                            productionByResourceTypeByJob.Add(job, new Dictionary<ResourceType, Production> { { resourceType, totalProduction } });
                        }
                        else
                        {
                            if (!productionByResourceTypeByJob[job].ContainsKey(resourceType))
                            {
                                productionByResourceTypeByJob[job].Add(resourceType, totalProduction);
                            }
                            else
                            {
                                productionByResourceTypeByJob[job][resourceType] += totalProduction;
                            }
                        }
                    }
                }
            }

            ApplyBuildingJobMultipliers(productionByResourceTypeByJob);
            ApplyPlanetSpecializationJobMultipliers(productionByResourceTypeByJob);

            Dictionary<ResourceType, Production> productionByResourceType = new Dictionary<ResourceType, Production>();

            foreach (Building building in Buildings)
            {
                foreach (var resourceTypeProduction in building.ProductionByResourceType)
                {
                    ResourceType resourceType = resourceTypeProduction.Key;
                    Production production = resourceTypeProduction.Value;

                    if (!productionByResourceType.ContainsKey(resourceType))
                    {
                        productionByResourceType.Add(resourceType, production);
                    }
                    else
                    {
                        productionByResourceType[resourceType] += production;
                    }
                }
            }

            foreach (var jobProductionByResourceType in productionByResourceTypeByJob)
            {
                Job job = jobProductionByResourceType.Key;
                Dictionary<ResourceType, Production> productionByResourceTypeLocal = jobProductionByResourceType.Value;

                foreach (var resourceTypeProduction in productionByResourceTypeLocal)
                {
                    ResourceType resourceType = resourceTypeProduction.Key;
                    Production production = resourceTypeProduction.Value;

                    if (!productionByResourceType.ContainsKey(resourceType))
                    {
                        productionByResourceType.Add(resourceType, production);
                    }
                    else
                    {
                        productionByResourceType[resourceType] += production;
                    }
                }
            }

            return productionByResourceType;
        }

        public int GetTotalJobs()
        {
            return Buildings.SelectMany(b => b.CountOfJobsByJob.Values).Sum() + Size * 2;
        }

        private void ApplyBuildingJobMultipliers(Dictionary<Job, Dictionary<ResourceType, Production>> productionByResourceTypeByJob)
        {
            foreach (var jobMultiplicator in Buildings.Where(b => b.JobMultipliers != null).SelectMany(b => b.JobMultipliers))
            {
                Job job = jobMultiplicator.Key;
                Production multiplicator = jobMultiplicator.Value;

                if (productionByResourceTypeByJob.ContainsKey(job))
                {
                    foreach (ResourceType resourceType in productionByResourceTypeByJob[job].Keys.ToArray())
                    {
                        Production production = productionByResourceTypeByJob[job][resourceType];

                        if (production.ProductionType == multiplicator.ProductionType)
                        {
                            productionByResourceTypeByJob[job][resourceType] *= multiplicator;
                        }
                    }
                }
            }
        }

        private void ApplyPlanetSpecializationJobMultipliers(Dictionary<Job, Dictionary<ResourceType, Production>> productionByResourceTypeByJob)
        {
            foreach (var jobProductionMultiplier in PlanetSpecialization.JobProductionMultipliers)
            {
                Job job = jobProductionMultiplier.Key;
                Production multiplicator = jobProductionMultiplier.Value;

                if (productionByResourceTypeByJob.ContainsKey(job))
                {
                    foreach (ResourceType resourceType in productionByResourceTypeByJob[job].Keys.ToArray())
                    {
                        Production production = productionByResourceTypeByJob[job][resourceType];

                        if (production.ProductionType == multiplicator.ProductionType)
                        {
                            productionByResourceTypeByJob[job][resourceType] *= multiplicator;
                        }
                    }
                }
            }
        }
    }
}
