using Fluxor;

namespace MassCalculator.Store.FromComposition;

public class FromCompositionFeature : Feature<FromCompositionState>
{
    public override string GetName() => "FromComposition";

    protected override FromCompositionState GetInitialState() => new("", null, 0.0);
}