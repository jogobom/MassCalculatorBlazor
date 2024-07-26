using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetMassOverChargeReducer : Reducer<ChargedToNeutralState, SetMassOverChargeAction>
    {
        private readonly MassConverterService _massConverterService;

        public SetMassOverChargeReducer(MassConverterService massConverterService) => this._massConverterService = massConverterService;

        public override ChargedToNeutralState Reduce(ChargedToNeutralState state, SetMassOverChargeAction action)
        {
            if (!action.MassOverCharge.HasValue)
            {
                return state;
            }

            var massOverCharge = action.MassOverCharge.Value;
            var neutralMass = MassConverterService.CalculateNeutralMass(massOverCharge, state.Charge).Result;
            var compound = _massConverterService.GenerateCompoundDetails(neutralMass).Result;
            return new ChargedToNeutralState(massOverCharge, state.Charge, compound);
        }
    }
}