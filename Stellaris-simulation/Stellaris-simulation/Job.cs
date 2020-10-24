using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris_simulation
{
    [DebuggerDisplay("{Name}")]
    public class Job
    {
        public string Name { get; set; }

        public Dictionary<ResourceType, Production> ProductionByResourceType { get; set; }

        public static Job Enforcer { get; set; }
        public static Job Administrator { get; set; }
        public static Job Artisan { get; set; }
        public static Job Translucer { get; set; }

        public Job(string name, Dictionary<ResourceType, Production> productionByResourceType)
        {
            Name = name;
            ProductionByResourceType = productionByResourceType;
        }

        static Job()
        {
            Dictionary<ResourceType, Production> productionByResourceType;

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Crime, new Production(ProductionType.Production, -30) },
                { ResourceType.DefenceArmies, new Production(ProductionType.Production, 2) },
                { ResourceType.Unity, new Production(ProductionType.Production, 1) },
            };
            Enforcer = new Job("Enforcer", productionByResourceType);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.Amenities, new Production(ProductionType.Production, 8) },
                { ResourceType.Unity, new Production(ProductionType.Production, 3) },
            };
            Administrator = new Job("Administrator", productionByResourceType);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.ConsumerGoods, new Production(ProductionType.Production, 6) },
                { ResourceType.Minerals, new Production(ProductionType.Upkeep, -6) },
            };
            Artisan = new Job("Artisan", productionByResourceType);

            productionByResourceType = new Dictionary<ResourceType, Production>()
            {
                { ResourceType.RareCrystals, new Production(ProductionType.Production, 2) },
                { ResourceType.Minerals, new Production(ProductionType.Upkeep, -10) },
            };
            Translucer = new Job("Translucer", productionByResourceType);
        }
    }
}
