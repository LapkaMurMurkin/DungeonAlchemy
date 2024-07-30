using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AlchemyUtils
{
    public static string GetRatioString(PotionFormula formula)
    {
        return GetRatioString(CalculateFormulaRatio(formula));
    }
    
    public static string GetRatioString(CookingElement[] elements)
    {
        return String.Join(" | ", elements.Select(element => $"{element.Element.Name}: {element.Ratio}").ToArray());
    }
    
    public static CookingElement[] CalculateFormulaRatio(PotionFormula formula)
    {
        CookingElement[] elements = new CookingElement[formula.ElementsForCooking.Count];
        int totalElements = 0;
        for (var i = 0; i < formula.ElementsForCooking.Count; i++)
        {
            var elementStack = formula.ElementsForCooking[i];
            elements[i] = new CookingElement(elementStack.Item);
            elements[i].Quantity = elementStack.Quantity;
            
            totalElements += elementStack.Quantity;
        }
        
        foreach (var element in elements)
            element.Ratio = element.Quantity * 1f / totalElements   ;

        return elements;
    }
}
