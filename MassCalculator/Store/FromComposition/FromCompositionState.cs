using MassCalculator.Data;

namespace MassCalculator.Store.FromComposition;

public class FromCompositionState(string formula, Compound? compound, double averageNeutralMass)
{
    public string Formula { get; } = formula;
    public Compound? Compound { get; } = compound;
}