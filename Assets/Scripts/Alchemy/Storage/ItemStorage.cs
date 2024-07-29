using ObservableCollections;
using R3;

public class ItemStorage<T> where T : AbstractItem
{
    public readonly ObservableList<Slot> Slots = new ObservableList<Slot>();
    private StorageData _storageData;

    public void Init(StorageData storageData)
    {
        _storageData = storageData;
        
        for (int i = 0; i < storageData.InitialSlots; i++)
        {
            Slot slot = new Slot();
            Slots.Add(slot);
            
            slot.Quantity.Subscribe(quantity =>
            {
                if (_storageData.DestroySlotAfterNoItems && quantity == 0)
                {
                    Slots.Remove(slot);
                }
            });
            slot.Item.Subscribe(item =>
            {
                if (_storageData.DestroySlotAfterNoItems && item == null)
                {
                    Slots.Remove(slot);
                }
            });
        }
    }

    public int AddOneItem(T item) => AddItemQuantity(item, 1);
    public int RemoveOneItem(T item) => RemoveItemQuantity(item, 1);
    
    public int AddItemQuantity(T item, int quantity)
    {
        int added = 0;
        
        if (!_storageData.CreateSlotForEachItem)
        {
            foreach (var slot in Slots)
            {
                int addedToSlot = slot.Add(item, quantity);
                quantity -= addedToSlot;
                added += addedToSlot;
                if (quantity == 0)
                    return added;
            }
        }
        
        if (_storageData.CreateSlotForEachItem)
        {
            foreach (var slot in Slots)
            {
                if (slot.Item.Value != item) continue;
                int addedToSlot = slot.Add(item, quantity);
                return addedToSlot;
            }
            
            var newSlot = new Slot();
            added += newSlot.Add(item, quantity);
            Slots.Add(newSlot);
        }

        return added;
    }
    
    public int RemoveItemQuantity(T item, int quantity)
    {
        int removed = quantity;
        
        foreach (var slot in Slots)
        {
            if (slot.Item.Value == item)
            {
                if (slot.Quantity.Value >= quantity)
                {
                    slot.Quantity.Value -= quantity;
                    quantity = 0;
                    break;
                }
                else
                {
                    quantity -= slot.Quantity.Value;
                    slot.Quantity.Value = 0;
                }
            }
        }

        foreach (var slot in Slots)
        {
            if (slot.Quantity.Value == 0)
            {
                if (!_storageData.ItemQuantityCanBeZero)
                    slot.Item.Value = null;
            }
        }

        removed -= quantity;

        return removed;
    }
}
