// Copyright © 2021 Waters Corporation. All Rights Reserved.

using Fluxor;

namespace MassCalculator.Store.MassError
{
    public class SetExpectedMassReducer : Reducer<MassErrorState, SetExpectedMassAction>
    {
        public override MassErrorState Reduce(MassErrorState state, SetExpectedMassAction action)
        {
            return action.ExpectedMass.HasValue ? new MassErrorState(state.ObservedMass, action.ExpectedMass.Value) : state;
        }
    }
}