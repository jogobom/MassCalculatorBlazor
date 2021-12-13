// Copyright © 2021 Waters Corporation. All Rights Reserved.

using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetChargeReducer : Reducer<ChargedToNeutralState, SetChargeAction>
    {
        private readonly MassConverterService massConverterService;

        public SetChargeReducer(MassConverterService massConverterService) => this.massConverterService = massConverterService;

        public override ChargedToNeutralState Reduce(ChargedToNeutralState state, SetChargeAction action)
        {
            if (!action.Charge.HasValue)
            {
                return state;
            }

            var charge = action.Charge.Value;
            var neutralMass = massConverterService.CalculateNeutralMass(state.MassOverCharge, charge).Result;
            return new ChargedToNeutralState(state.MassOverCharge, charge, neutralMass);
        }
    }
}