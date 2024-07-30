using UnityEngine;

public class AlchemyInitializer : MonoBehaviour
{
    [SerializeField] private AlchemyData _alchemyData;
    [SerializeField] private ItemDragger _itemDragger;
    
    [SerializeField] private FormulaListView _formulasListView;

    public void Init()
    {
        ServiceLocator.Register(_alchemyData);
        ServiceLocator.Register(_itemDragger);
        
        foreach (var inventory in GetComponentsInChildren<Inventory>()) 
            inventory.Init();

        foreach (var adder in GetComponentsInChildren<ItemAdder>()) 
            adder.Add();

        PotionsDatabase database = new PotionsDatabase();
        database.Init(_alchemyData);
        
        Cauldron cauldron = GetComponentInChildren<Cauldron>();
        cauldron.Init(_alchemyData, database);
        cauldron.InventoryReceiver = GetComponentInChildren<PotionInventory>();
        ServiceLocator.Register(cauldron);

        var formulasList = new FormulasList();
        _formulasListView.Init(formulasList);
        foreach (var formula in _alchemyData.PotionFormulas)
            formulasList.Add(formula);
        ServiceLocator.Register(formulasList);
        
        var formulaSelector = new FormulaSelector();
        formulaSelector.Init(formulasList);
        ServiceLocator.Register(formulaSelector);
    }
}
