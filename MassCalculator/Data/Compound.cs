using System;
using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class Compound
    {
        public Mass NeutralMass { get; init; } = new();
        public List<ChargeState> ChargeStates { get; init; } = new();
        public List<ChargeState> NegativeChargeStates { get; init; } = new();
        public int IsotopeCount => ChargeStates.Max(c => c.Isotopes.Count);
    }
}
