using System.Linq;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeasuringTubeView : MonoBehaviour
{
    public Slider FormulaRequirement;
    public Image ElementImage;
    
    public Image Filler;
    public TMP_Text ValueTMP;
    public CookingElement Element { get; private set; }
    private FormulaSelector _selector;
    
    public void Init(CookingElement element)
    {
        Element = element;
        ElementImage.sprite = element.Element.Sprite;
        Filler.color = element.Element.Color;
        Filler.fillAmount = 0f;
        _selector = ServiceLocator.Get<FormulaSelector>();

        _selector.CurrentFormulaEntry.Subscribe(elementValue =>
        {
            CookingElement element1 = elementValue.Ratios.FirstOrDefault(element => element.Element == Element.Element);
            FormulaRequirement.value = element1?.Ratio ?? 0f;
        });
    }

    public void RefreshUI()
    {
        CookingElement element = _selector.CurrentFormulaEntry.Value.Ratios.FirstOrDefault(element => element.Element == Element.Element);
        FormulaRequirement.value = element?.Ratio ?? 0f;
        
        Filler.fillAmount = Element.Ratio;
        ValueTMP.text = $"{Element.Quantity}";
    }
}
