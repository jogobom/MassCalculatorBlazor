// // Copyright © 2021 Waters Corporation. All Rights Reserved.

using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.Index
{
    public class SetNeutralMassReducer : Reducer<NeutralToChargedState, SetNeutralMassAction>
    {
        private readonly MassConverterService massConverterService;

        public SetNeutralMassReducer(MassConverterService massConverterService) => this.massConverterService = massConverterService;

        public override NeutralToChargedState Reduce(NeutralToChargedState state, SetNeutralMassAction action)
        {
            if (!action.CompoundMass.HasValue)
            {
                return state;
            }

            var compound = massConverterService.GenerateCompoundDetails(action.CompoundMass.Value).Result;
            return new NeutralToChargedState(compound);
        }
    }
}