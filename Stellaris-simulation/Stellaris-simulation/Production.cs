using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris_simulation
{
    [DebuggerDisplay("{Value}")]
    public class Production
    {
        public ProductionType ProductionType { get; set; }

        public decimal Value { get; set; }

        public Production(ProductionType productionType, decimal value)
        {
            ProductionType = productionType;
            Value = value;
        }

        public static Production operator *(Production production, decimal value)
        {
            return new Production(production.ProductionType, production.Value * value);
        }

        public static Production operator *(Production production1, Production production2)
        {
            return new Production(production1.ProductionType, production1.Value * production2.Value);
        }

        public static Production operator +(Production production1, Production production2)
        {
            return new Production(production1.ProductionType, production1.Value + production2.Value);
        }
    }
}
