using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionZoneDropReceiver : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PotionActor _caster;
    public PotionActor _target;

    private ItemDragger _dragger;

    public void Start()
    {
        _dragger = ServiceLocator.Get<ItemDragger>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("PotionDrop");
        _dragger.GotDrop(eventData.pointerDrag.GetComponent<DraggableTrigger>().Slot, _caster, _target);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image image = GetComponent<Image>();
        Color colorBuffer = image.color;
        colorBuffer.a = 0f;
        image.color = colorBuffer;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Image image = GetComponent<Image>();
        Color colorBuffer = image.color;
        colorBuffer.a = 0.15f;
        image.color = colorBuffer;
    }
}
