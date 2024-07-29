using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableTrigger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ItemCard _itemInstance;
    private RectTransform _rectTransform;
    
    private Slot _slot;
    private ItemDragger _dragger;

    public Slot Slot => _slot;
    
    public void Init(Slot slot)
    {
        _slot = slot;
        _dragger = ServiceLocator.Get<ItemDragger>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_slot.Quantity.Value == 0) return;
        _dragger.DragStarted(this, _slot, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragger.Drag(this, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragger.DragEnded(this);
    }
}
