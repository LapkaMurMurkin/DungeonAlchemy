using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected TMP_Text _quantityTMP;
    [SerializeField] protected DraggableTrigger _draggableTrigger;
    [SerializeField] protected SlotDropReceiver _dropReceiver;
    
    private Slot _slot;
    
    public virtual void Init(Slot slot)
    {
        _slot = slot;
        if (_dropReceiver is not null)
            _dropReceiver.Init(slot);
        _draggableTrigger.Init(slot);
        slot.Item.Subscribe(item =>
        {
            if (item is null)
            {
                _image.sprite = null;
                Color newColor = _image.color;
                newColor.a = 0;
                _image.color = newColor;
                _quantityTMP.gameObject.SetActive(false);
            }
            else
            {
                _image.sprite = item.Sprite;
                Color newColor = _image.color;
                newColor.a = 1;
                _image.color = newColor;

                _quantityTMP.gameObject.SetActive(item.IsStackable);
            }
        });
        
        slot.Quantity.Subscribe(quantity => _quantityTMP.text = $"{quantity}");
    }
    
}
