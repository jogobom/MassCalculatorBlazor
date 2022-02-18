// Copyright © 2022 Waters Corporation. All Rights Reserved.

using System.Collections.Generic;
using System.Linq;
using Fluxor;
using MassCalculator.Data;
using OxyPlot;

namespace MassCalculator.Store.IsotopePrediction;

public class SetFormulaReducer : Reducer<IsotopePredictionState, SetFormulaAction>
{
    private readonly IsotopePatternCalculator isotopePatternCalculator = new(ElementDatabase.LoadFromFile("Data/ElementDatabase.json"));

    public override IsotopePredictionState Reduce(IsotopePredictionState state, SetFormulaAction action)
    {
        if (string.IsNullOrEmpty(action.Formula))
        {
            return state;
        }

        var composition = Composition.FromFormula(action.Formula);

        var predictedIsotopes = composition.Ingredients.Any()
            ? isotopePatternCalculator.PredictIsotopesFromCompositionAsParallel(composition).Select(i => new DataPoint(i.Mass, i.Intensity))
            : new List<DataPoint>();

        return new IsotopePredictionState(action.Formula, composition, predictedIsotopes);
    }
}