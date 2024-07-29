using UnityEngine;
using UnityEngine.EventSystems;

public class ItemCauldronDropReceiver : MonoBehaviour, IDropHandler
{
    private ItemDragger _dragger;
    private Cauldron _cauldron;

    public void Start()
    {
        _dragger = ServiceLocator.Get<ItemDragger>();
        _cauldron = ServiceLocator.Get<Cauldron>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        _dragger.GotDrop(eventData.pointerDrag.GetComponent<DraggableTrigger>().Slot, _cauldron);
    }
}
