﻿// // Copyright © 2021 Waters Corporation. All Rights Reserved.

namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetMassOverChargeAction
    {
        public double? MassOverCharge { get; }

        public SetMassOverChargeAction(double? massOverCharge) => MassOverCharge = massOverCharge;
    }
}