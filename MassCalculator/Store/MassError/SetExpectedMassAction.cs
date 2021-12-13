// Copyright © 2021 Waters Corporation. All Rights Reserved.

namespace MassCalculator.Store.MassError
{
    public class SetExpectedMassAction
    {
        public double? ExpectedMass { get; }

        public SetExpectedMassAction(double? expectedMass) => ExpectedMass = expectedMass;
    }
}