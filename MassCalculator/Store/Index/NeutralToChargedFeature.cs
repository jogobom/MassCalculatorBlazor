using Fluxor;

namespace MassCalculator.Store.Index;

public class NeutralToChargedFeature : Feature<NeutralToChargedState>
{
    public override string GetName() => "NeutralToCharged";

    protected override NeutralToChargedState GetInitialState() => new(null);
}