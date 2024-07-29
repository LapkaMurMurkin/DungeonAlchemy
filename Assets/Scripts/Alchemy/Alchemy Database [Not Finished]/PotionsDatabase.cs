using ObservableCollections;
using UnityEngine;

public class PotionsDatabase
{
    private ObservableDictionary<string, Potion> _potionRatios = new ObservableDictionary<string, Potion>();
    
    public void Init(AlchemyData data)
    {
        foreach (var formula in data.PotionFormulas)
        {
            string FormulaRatio = AlchemyUtils.GetRatioString(CalculateFormulaRatio(formula));
            _potionRatios.Add(FormulaRatio, formula.Potion);
            Debug.Log($"{formula.Potion.Name}: {FormulaRatio}");
        }
    }

    public Potion GetPotion(string ratio)
    {
        if (_potionRatios.TryGetValue(ratio, out Potion potion))
        {
            return potion;
        }
        
        Debug.Log("Potion Not Found");
        return null;
    }

    private CookingElement[] CalculateFormulaRatio(PotionFormula formula)
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
