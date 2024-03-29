﻿using Fluxor;

namespace MassCalculator.Store.MassError
{
    public class MassErrorFeature : Feature<MassErrorState>
    {
        public override string GetName() => "MassError";

        protected override MassErrorState GetInitialState() => new(0, 0);
    }
}