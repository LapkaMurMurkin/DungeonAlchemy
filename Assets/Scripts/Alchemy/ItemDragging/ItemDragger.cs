using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour
{
    public Canvas WorldCanvas;
    public ItemCard DragAndDropPrefab;
    public Transform Container;
    
    private ItemCard _itemInstance;
    private RectTransform _rectTransform;
    private Slot _slot;

    private ItemStack<AbstractItem> _itemStack;
    private bool _dropReceived;

    private bool _dragStarted;
    
    public void DragStarted(DraggableTrigger draggableTrigger, Slot slot, PointerEventData eventData)
    {
        _slot = slot;

        _itemStack = new ItemStack<AbstractItem>();
        _itemStack.Item = slot.Item.Value;
        _itemStack.Quantity = slot.Inventory.Storage.RemoveOneItem(slot.Item.Value);
        slot.IsLocked = true;
        
        _itemInstance = Instantiate(DragAndDropPrefab, Container);
        _itemInstance.Image.sprite = _itemStack.Item.Sprite;
        _itemInstance.QuantityTMP.text = $"1";
        _itemInstance.GetComponent<CanvasGroup>().blocksRaycasts = false;
        _itemInstance.GetComponent<Canvas>().overrideSorting = true;

        _rectTransform = _itemInstance.GetComponent<RectTransform>();
        _rectTransform.position = draggableTrigger.transform.position;
        
        _dropReceived = false;
        _dragStarted = true;
    }
    
    public void Drag(DraggableTrigger draggableTrigger, PointerEventData eventData)
    {
        if (!_dragStarted) return;
        _rectTransform.anchoredPosition += eventData.delta / WorldCanvas.scaleFactor;
    }

    public void GotDrop(Slot from, PotionActor caster, PotionActor target)
    {
        if (!_dragStarted) return;
        if (from != _slot) return;
        if (_itemStack.Item is Potion potion)
        {
            from.Quantity.Value = 0;
            potion.Apply(caster, target);
        }
    }

    public void GotDrop(Slot from, Slot to)
    {
        if (!_dragStarted) return;
        if (from != _slot) return;
        
        if (to.Item.Value == null || (to.Item.Value != null && !to.Item.Value.IsStackable))
            Slot.Swap(to, from);
        
        _dropReceived = to.Add(_itemStack.Item, _itemStack.Quantity) == 1;
    }

    public void GotDrop(Slot from, Cauldron cauldron)
    {
        if (!_dragStarted) return;
        if (from != _slot) return;
        if (_itemStack.Item is Ingredient item)
            _dropReceived = cauldron.AddIngredient(item) == 1;
    }

    public void DragEnded(DraggableTrigger draggableTrigger)
    {
        if (!_dragStarted) return;
        _itemInstance.GetComponent<CanvasGroup>().blocksRaycasts = true;
        _itemInstance.GetComponent<Canvas>().overrideSorting = false;
        Destroy(_itemInstance.gameObject);

        _slot.IsLocked = false; 
        if (!_dropReceived)
            _slot.Inventory.Storage.AddItemQuantity(_itemStack.Item, 1);
        
        _slot = null;
        _dragStarted = false;
    }
}
