namespace MassCalculator.Store.MassError
{
    public class MassErrorState
    {
        public double ObservedMass { get; }
        public double ExpectedMass { get; }
        public double MassErrorPpm => (ObservedMass - ExpectedMass) / ExpectedMass * 1e6;

        public MassErrorState(double observedMass, double expectedMass)
        {
            ObservedMass = observedMass;
            ExpectedMass = expectedMass;
        }
    }
}