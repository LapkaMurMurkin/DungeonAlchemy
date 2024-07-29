using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDropReceiver : MonoBehaviour, IDropHandler
{
    private ItemDragger _dragger;
    private Cauldron _cauldron;
    private Slot _slot;

    public void Init(Slot slot)
    {
        _slot = slot;
        _dragger = ServiceLocator.Get<ItemDragger>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        _dragger.GotDrop(eventData.pointerDrag.GetComponent<DraggableTrigger>().Slot, _slot);
    }
}
