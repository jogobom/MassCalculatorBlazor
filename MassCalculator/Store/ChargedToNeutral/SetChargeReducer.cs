using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetChargeReducer(MassConverterService massConverterService)
        : Reducer<ChargedToNeutralState, SetChargeAction>
    {
        public override ChargedToNeutralState Reduce(ChargedToNeutralState state, SetChargeAction action)
        {
            if (!action.Charge.HasValue)
            {
                return state;
            }

            var charge = action.Charge.Value;
            var neutralMass = MassConverterService.CalculateNeutralMass(state.MassOverCharge, charge).Result;
            var compound = massConverterService.GenerateCompoundDetails(neutralMass).Result;
            return new ChargedToNeutralState(state.MassOverCharge, charge, compound);
        }
    }
}