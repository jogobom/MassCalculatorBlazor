// Copyright © 2021 Waters Corporation. All Rights Reserved.

namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetChargeAction
    {
        public int? Charge { get; }

        public SetChargeAction(int? charge) => Charge = charge;
    }
}