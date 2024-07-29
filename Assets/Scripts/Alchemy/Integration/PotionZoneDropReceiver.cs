using UnityEngine;
using UnityEngine.EventSystems;

public class PotionZoneDropReceiver : MonoBehaviour
{
    [SerializeField] private PotionActor _caster;
    [SerializeField] private PotionActor _target;
    
    private ItemDragger _dragger;

    public void Start()
    {
        _dragger = ServiceLocator.Get<ItemDragger>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        _dragger.GotDrop(eventData.pointerDrag.GetComponent<DraggableTrigger>().Slot, _caster, _target);
    }
}
