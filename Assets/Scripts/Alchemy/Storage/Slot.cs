using R3;
using UnityEngine;

public class Slot
{
    public Inventory Inventory { get; set; }
    
    public ReactiveProperty<AbstractItem> Item {get;} = new ReactiveProperty<AbstractItem>() ;
    public ReactiveProperty<int> Quantity {get;} = new ReactiveProperty<int>();

    public bool IsEmpty => (Item.Value == null || (!Inventory.StorageData.ItemQuantityCanBeZero && Quantity.Value == 0)) && !IsLocked;
    public bool IsLocked { get; set; }
    
    public int Add(AbstractItem item, int quantity)
    {
        if (IsLocked) return 0;
        int added = 0;
        if (item.IsStackable && Item.Value == item)
        {
            Quantity.Value += quantity;
            added += quantity;
            return added;
        }
        
        if (IsEmpty)
        {
            Item.Value = item;

            if (item.IsStackable)
            {
                Quantity.Value += quantity;
                added += quantity;
                return added;
            }

            if (!item.IsStackable)
            {
                if (quantity <= 0) Debug.LogWarning($"adding {quantity}");
                Quantity.Value += 1;
                return 1;
            }
        }
        return added;
    }

    public int RemoveOne()
    {
        if (IsLocked) return 0;
        if (IsEmpty) return 0;
        
        Quantity.Value -= 1;
        if (!Inventory.StorageData.ItemQuantityCanBeZero && Quantity.Value == 0)
            Item.Value = null;

        return 1;
    }

    public static bool Swap(Slot slot1, Slot slot2)
    {
        if (slot1.Inventory.Storage.GetType() != slot2.Inventory.Storage.GetType())
        {
            Debug.LogWarning("Swapping two items from different types of storages");
            return false;
        }
        
        (slot1.Item.Value, slot2.Item.Value) = (slot2.Item.Value, slot1.Item.Value);
        (slot1.Quantity.Value, slot2.Quantity.Value) = (slot2.Quantity.Value, slot1.Quantity.Value);
        
        return true;
    }
}
