namespace MassCalculator.Store.MassError
{
    public class SetObservedMassAction
    {
        public double? ObservedMass { get; }

        public SetObservedMassAction(double? observedMass) => ObservedMass = observedMass;
    }
}