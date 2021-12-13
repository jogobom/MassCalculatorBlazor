// // Copyright © 2021 Waters Corporation. All Rights Reserved.

using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetMassOverChargeReducer : Reducer<ChargedToNeutralState, SetMassOverChargeAction>
    {
        private readonly MassConverterService massConverterService;

        public SetMassOverChargeReducer(MassConverterService massConverterService) => this.massConverterService = massConverterService;

        public override ChargedToNeutralState Reduce(ChargedToNeutralState state, SetMassOverChargeAction action)
        {
            if (!action.MassOverCharge.HasValue)
            {
                return state;
            }

            var massOverCharge = action.MassOverCharge.Value;
            var neutralMass = massConverterService.CalculateNeutralMass(massOverCharge, state.Charge).Result;
            return new ChargedToNeutralState(massOverCharge, state.Charge, neutralMass);
        }
    }
}