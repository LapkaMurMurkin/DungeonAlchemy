using ObservableCollections;
using R3;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public StorageData StorageData;
    public ItemStorageView View;
    public ItemStorage<AbstractItem> Storage { get; } = new ItemStorage<AbstractItem>();

    public bool IsFull()
    {
        foreach (var slot in Storage.Slots)
            if (slot.IsEmpty) return false;
        
        return true;
    }

    public void Init()
    {
        Storage.Slots.ObserveAdd().Subscribe(slot => slot.Value.Inventory = this);
        
        
        View.Init(Storage);
        Storage.Init(StorageData);
    }
}
