using System;
using System.Collections.Generic;
using System.Linq;
using Fluxor;
using MassCalculator.Data;
using OxyPlot;

namespace MassCalculator.Store.IsotopePrediction;

public class SetFormulaReducer : Reducer<IsotopePredictionState, SetFormulaAction>
{
    private readonly IsotopePatternCalculator _isotopePatternCalculator = new(ElementDatabase.LoadFromFile("Data/ElementDatabase.json"));

    public override IsotopePredictionState Reduce(IsotopePredictionState state, SetFormulaAction action)
    {
        if (string.IsNullOrEmpty(action.Formula))
        {
            return state;
        }

        try
        {
            var composition = Composition.FromFormula(action.Formula);

            var predictedIsotopes = composition.Ingredients.Any()
                ? _isotopePatternCalculator.PredictIsotopesFromCompositionAsParallel(composition).Select(i => new DataPoint(i.Mass, i.Intensity))
                : new List<DataPoint>();

            return new(action.Formula, composition, predictedIsotopes);
        }
        catch (Exception)
        {
            return new(action.Formula, null, new List<DataPoint>());
        }
    }
}