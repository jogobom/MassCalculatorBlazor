using MassCalculator.Data;

namespace MassCalculator.Store.Index
{
    public class NeutralToChargedState
    {
        public Compound? Compound { get;  }

        public NeutralToChargedState(Compound? compound)
        {
            Compound = compound;
        }
    }
}