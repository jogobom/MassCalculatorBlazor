using System.Collections.Generic;

namespace MassCalculator.Data
{
    public class ChargeState
    {
        public int Charge { get; set; }
        public List<PredictedIsotopeAtCharge> Isotopes { get; init; } = new();
        public Mass? MassOverChargeRatio { get; set; }
    }
}