using System.Collections.Generic;
using ObservableCollections;
using R3;
using UnityEngine;

public class ItemStorageView : MonoBehaviour
{
    public SlotView SlotPrefab;
    public Transform SlotContainer;

    private Dictionary<Slot, SlotView> _slotViews = new Dictionary<Slot, SlotView>();

    public void Init(ItemStorage<AbstractItem> storage)
    {   
        ClearContainer();
        storage.Slots.ObserveAdd().Subscribe(slot => CreateSlot(slot.Value));
        storage.Slots.ObserveRemove().Subscribe(slot => RemoveSlot(slot.Value));
    }
    
    private void CreateSlot(Slot slot)
    {
        SlotView SlotView = Instantiate(SlotPrefab, SlotContainer);
        SlotView.Init(slot);
        _slotViews.Add(slot, SlotView);
    }

    private void RemoveSlot(Slot slot)
    {
        Destroy(_slotViews[slot].gameObject);
        _slotViews.Remove(slot);
    }

    private void ClearContainer()
    {
        foreach (Transform child in SlotContainer)
            Destroy(child.gameObject);
    }
}
