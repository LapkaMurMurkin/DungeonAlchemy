using System;
using System.Collections.Generic;

public class FormulasList
{
    private List<FormulaListEntry> _formulas = new  List<FormulaListEntry>();
    
    public event Action<FormulaListEntry> Added;

    public FormulaListEntry Get(string formulaKey)
    {
        foreach (var formula in _formulas)
        {
            if (formula.FormulaKey == formulaKey)
                return formula;
        }

        return null;
    }
    
    public FormulaListEntry Get(int value)
    {
        return _formulas[value];
    }
    
    public void Add(PotionFormula formula)
    {
        var formulaEntry = new FormulaListEntry()
        {
            Ratios = AlchemyUtils.CalculateFormulaRatio(formula),
            FormulaKey = AlchemyUtils.GetRatioString(formula),
            Formula = formula                                 
        };
        
        _formulas.Add(formulaEntry);
        Added?.Invoke(formulaEntry);
    }
}

public class FormulaListEntry
{
    public string FormulaKey;
    public CookingElement[] Ratios;
    public PotionFormula Formula;
}
