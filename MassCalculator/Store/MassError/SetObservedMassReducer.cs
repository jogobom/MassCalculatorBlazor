// Copyright © 2021 Waters Corporation. All Rights Reserved.

using Fluxor;

namespace MassCalculator.Store.MassError
{
    public class SetObservedMassReducer : Reducer<MassErrorState, SetObservedMassAction>
    {
        public override MassErrorState Reduce(MassErrorState state, SetObservedMassAction action)
        {
            return action.ObservedMass.HasValue ? new MassErrorState(action.ObservedMass.Value, state.ExpectedMass) : state;
        }
    }
}