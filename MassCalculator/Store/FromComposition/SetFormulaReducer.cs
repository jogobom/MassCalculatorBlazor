using System;
using System.Linq;
using Fluxor;
using MassCalculator.Data;

namespace MassCalculator.Store.FromComposition;

public class SetFormulaReducer(MassConverterService massConverterService)
    : Reducer<FromCompositionState, SetFormulaAction>
{
    private readonly ElementDatabase _elementDatabase = ElementDatabase.LoadFromFile("Data/ElementDatabase.json");

    public override FromCompositionState Reduce(FromCompositionState state, SetFormulaAction action)
    {
        if (string.IsNullOrEmpty(action.Formula))
        {
            return state;
        }

        try
        {
            var composition = Composition.FromFormula(action.Formula);
            var monoisotopicNeutralMass = composition.Ingredients.Sum(i => _elementDatabase.GetMonoisotopicMass(i.ElementSymbol) * i.Quantity);
            var averageNeutralMass = composition.Ingredients.Sum(i => _elementDatabase.GetAverageMass(i.ElementSymbol) * i.Quantity);
            var mass = new Mass { Monoisotopic = monoisotopicNeutralMass, Average = averageNeutralMass };
            var compound = massConverterService.GenerateCompoundDetails(mass).Result;
            return new(action.Formula, compound, averageNeutralMass);
        }
        catch (Exception)
        {
            return new(action.Formula, null, 0.0);
        }
    }
}