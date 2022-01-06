namespace MassCalculator.Store.Index
{
    public class SetNeutralMassAction
    {
        public double? CompoundMass { get; }

        public SetNeutralMassAction(double? compoundMass) => CompoundMass = compoundMass;
    }
}