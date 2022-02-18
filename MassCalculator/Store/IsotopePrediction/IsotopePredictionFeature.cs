// Copyright © 2022 Waters Corporation. All Rights Reserved.

using System.Collections.Generic;
using Fluxor;
using OxyPlot;

namespace MassCalculator.Store.IsotopePrediction;

public class IsotopePredictionFeature : Feature<IsotopePredictionState>
{
    public override string GetName() => "IsotopePrediction";

    protected override IsotopePredictionState GetInitialState() => new("", null, new List<DataPoint>());
}