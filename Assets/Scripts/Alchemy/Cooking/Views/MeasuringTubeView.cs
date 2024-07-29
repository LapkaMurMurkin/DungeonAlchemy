using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeasuringTubeView : MonoBehaviour
{
    public Image Filler;
    public TMP_Text ValueTMP;
    public CookingElement Element { get; private set; }

    public void Init(CookingElement element)
    {
        Element = element;
        Filler.color = element.Element.Color;
        Filler.fillAmount = 0f;
    }

    public void RefreshUI()
    {
        Filler.fillAmount = Element.Ratio;
        ValueTMP.text = $"{Element.Quantity}";
    }
}
