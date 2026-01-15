using MassCalculator.Data;

namespace MassCalculator.Store.FromComposition;

public class FromCompositionState(string formula, Compound? compound)
{
    public string Formula { get; } = formula;
    public Compound? Compound { get; } = compound;
}