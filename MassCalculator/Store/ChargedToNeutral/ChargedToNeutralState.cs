// Copyright © 2021 Waters Corporation. All Rights Reserved.

using MassCalculator.Data;

namespace MassCalculator.Store.ChargedToNeutral
{
    public class ChargedToNeutralState
    {
        public double MassOverCharge { get; }
        public double? NeutralMass { get; }
        public int Charge { get; }

        public ChargedToNeutralState(double? massOverCharge, int? charge, double? neutralMass)
        {
            MassOverCharge = massOverCharge ?? 0;
            Charge = charge ?? 1;
            NeutralMass = neutralMass ?? 0;
        }
    }
}