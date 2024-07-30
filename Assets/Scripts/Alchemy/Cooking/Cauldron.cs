using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public float DefaultTimerValue = 2f;
    public float IngredientTimeMultiplier = 1f;
    
    public Inventory InventoryReceiver;

    private Dictionary<Element, CookingElement> _elements = new Dictionary<Element, CookingElement>();
    private List<Ingredient> _ingredients = new List<Ingredient>();

    private AlchemyData _data;
    private PotionsDatabase _database;

    public bool IsCooking => _timeLeft.Value > 0f;
    private ReactiveProperty<float> _timeLeft = new ReactiveProperty<float>();

    public Dictionary<Element, CookingElement> Elements => _elements;
    public ReadOnlyReactiveProperty<float> TimeLeft => _timeLeft;
    public event Action RatioChanged;

    private Coroutine _potionRoutine;

    public bool CanCook => !(IsCooking || InventoryReceiver.IsFull());

    public void Init(AlchemyData data, PotionsDatabase database)
    {
        _database = database;
        _data = data;
            
        foreach (var element in data.Elements) 
            _elements[element] = new CookingElement(element);
        
        UpdateRatios();
    }

    public void StartCooking()
    {
        if (!CanCook) return;
        _timeLeft.Value = DefaultTimerValue + IngredientTimeMultiplier * _ingredients.Sum(x => x.AdditionalCookingTime);
        _potionRoutine = StartCoroutine(CookingTimerCoroutine());
    }

    public void FinishCooking()
    {
        Debug.Log(AlchemyUtils.GetRatioString(_elements.Values.Where(x => x.Quantity > 0).ToArray()));
        Potion potion = _database.GetPotion(AlchemyUtils.GetRatioString(_elements.Values.Where(x => x.Quantity > 0).ToArray()));
        
        if (potion is not null)
            InventoryReceiver.Storage.AddOneItem(potion);
        
        ClearCauldron();
        UpdateRatios();
    }

    private IEnumerator CookingTimerCoroutine()
    {
        while (_timeLeft.Value > 0f)
        {
            _timeLeft.Value -= Time.deltaTime;
            yield return null;
        }

        FinishCooking();
    }

    public int AddIngredient(Ingredient ingredient) => AddIngredients(ingredient, 1);
    public int AddIngredients(Ingredient ingredient, int quantity)
    {
        int added = 0;
        if (IsCooking) return 0;
        
        foreach (ItemStack<Element> elementStack in ingredient.Elements) 
            _elements[elementStack.Item].Quantity += elementStack.Quantity;
        
        _ingredients.Add(ingredient);
        added = quantity;

        UpdateRatios();
        return added;
    }

    private void ClearCauldron()
    {
        foreach (var element in _elements.Values) 
            element.Quantity = 0;
        _ingredients.Clear();
    }

    private void UpdateRatios()
    { 
        int totalElements = _elements.Values.Sum(element => element.Quantity);
        
        if (totalElements != 0)
        {
            foreach (var element in _elements.Values) 
                element.Ratio = element.Quantity * 1f / totalElements;
        }
        else
        {
            foreach (var element in _elements.Values) 
                element.Ratio = 0;
        }

        RatioChanged?.Invoke();
    }
}