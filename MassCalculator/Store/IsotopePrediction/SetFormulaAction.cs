// Copyright © 2022 Waters Corporation. All Rights Reserved.

namespace MassCalculator.Store.IsotopePrediction;

public class SetFormulaAction
{
    public string Formula { get; }

    public SetFormulaAction(string formula) => Formula = formula;
}