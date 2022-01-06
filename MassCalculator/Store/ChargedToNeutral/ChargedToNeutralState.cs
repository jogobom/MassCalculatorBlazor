using MassCalculator.Data;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class ChargedToNeutralState
    {
        public double MassOverCharge { get; }
        public Compound? Compound { get; }
        public int Charge { get; }

        public ChargedToNeutralState(double? massOverCharge, int? charge, Compound? compound)
        {
            MassOverCharge = massOverCharge ?? 0;
            Charge = charge ?? 1;
            Compound = compound;
        }
    }
}