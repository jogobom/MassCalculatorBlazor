using Fluxor;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class ChargedToNeutralFeature : Feature<ChargedToNeutralState>
    {
        public override string GetName() => "ChargedToNeutral";

        protected override ChargedToNeutralState GetInitialState() => new(null, null, null);
    }
}