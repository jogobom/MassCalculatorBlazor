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
            var neutralMonoisotopicMass = massConverterService.CalculateNeutralMass(state.MassOverCharge, charge).Result;
            var compound = massConverterService.GenerateCompoundDetails(neutralMonoisotopicMass).Result;
            return new ChargedToNeutralState(state.MassOverCharge, charge, compound);
        }
    }
}