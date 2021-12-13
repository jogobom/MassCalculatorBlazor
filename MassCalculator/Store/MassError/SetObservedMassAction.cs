// Copyright © 2021 Waters Corporation. All Rights Reserved.

namespace MassCalculator.Store.MassError
{
    public class SetObservedMassAction
    {
        public double? ObservedMass { get; }

        public SetObservedMassAction(double? observedMass) => ObservedMass = observedMass;
    }
}