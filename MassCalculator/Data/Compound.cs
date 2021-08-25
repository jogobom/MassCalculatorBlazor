using System;
using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class Compound
    {
        public double NeutralMonoisotopicMass { get; set; }
        public List<ChargeState> ChargeStates { get; set; }
        public List<ChargeState> NegativeChargeStates { get; set; }
        public int IsotopeCount => ChargeStates.Max(c => c.Isotopes.Count);
    }
}
