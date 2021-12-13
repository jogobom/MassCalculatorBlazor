// Copyright © 2021 Waters Corporation. All Rights Reserved.

using MassCalculator.Data;

namespace MassCalculator.Store.Index
{
    public class NeutralToChargedState
    {
        public Compound? Compound { get;  }

        public NeutralToChargedState(Compound? compound)
        {
            Compound = compound;
        }
    }
}