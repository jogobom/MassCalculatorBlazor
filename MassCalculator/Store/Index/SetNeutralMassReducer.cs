using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.Index;

public class SetNeutralMassReducer : Reducer<NeutralToChargedState, SetNeutralMassAction>
{
    private readonly MassConverterService _massConverterService;

    public SetNeutralMassReducer(MassConverterService massConverterService) => this._massConverterService = massConverterService;

    public override NeutralToChargedState Reduce(NeutralToChargedState state, SetNeutralMassAction action)
    {
        if (!action.CompoundMass.HasValue)
        {
            return state;
        }

        var compound = _massConverterService.GenerateCompoundDetails(action.CompoundMass.Value).Result;
        return new NeutralToChargedState(compound);
    }
}