using ObservableCollections;
using UnityEngine;

public class PotionsDatabase
{
    private ObservableDictionary<string, Potion> _potionRatios = new ObservableDictionary<string, Potion>();
    
    public void Init(AlchemyData data)
    {
        foreach (var formula in data.PotionFormulas)
        {
            string FormulaRatio = AlchemyUtils.GetRatioString(formula);
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
}
