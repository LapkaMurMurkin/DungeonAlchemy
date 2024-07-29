using R3;
using UnityEngine;

public class IngredientSlotView : SlotView
{
    public Transform ElementsContainer;
    public ItemCard ElementSlotPrefab;
    private AlchemyData _alchemyData;

    public override void Init(Slot slot)
    {
        base.Init(slot);
        _alchemyData = ServiceLocator.Get<AlchemyData>();
        
        slot.Item.Subscribe(item =>
        {
            foreach (Transform child in ElementsContainer)
                Destroy(child.gameObject);

            if (item is null) return;

            Ingredient ingredientItem = item as Ingredient;

            foreach (ItemStack<Element> elementStack in ingredientItem.Elements)
            {
                if (!_alchemyData.Elements.Contains(elementStack.Item)) 
                    Debug.LogWarning($"{item.Name} contains element not defined in alchemy data");
            }

            foreach (Element element in _alchemyData.Elements)
            {
                foreach (ItemStack<Element> elementStack in ingredientItem.Elements)
                {
                    if (element == elementStack.Item)
                    {
                        ItemCard elementView = Instantiate(ElementSlotPrefab, ElementsContainer);
                        elementView.Image.sprite = element.Sprite;
                        elementView.QuantityTMP.text = $"{elementStack.Quantity}";
                    }
                }
            }
        });
    }
}
