namespace MassCalculator.Store.FromComposition;

public class SetFormulaAction
{
    public string Formula { get; }

    public SetFormulaAction(string formula) => Formula = formula;
}