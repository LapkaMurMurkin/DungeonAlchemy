using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormulaSelectorView : MonoBehaviour
{
    public Button Button;
    public Image Image;
    public TMP_Text TextName;
    public TMP_Text TextDescription;
    public GameObject FormulasList;
    
    public void Start()
    {
        var selector = ServiceLocator.Get<FormulaSelector>();
        
        selector.CurrentFormulaEntry.Subscribe(formula =>
        {
            Image.sprite = formula.Formula.Potion.Sprite;
            TextName.text = $"{formula.Formula.Potion.Name}";
            TextDescription.text = $"{formula.Formula.Potion.Description}";
        });
        
        GetComponent<Button>().onClick.AddListener(ToggleFormulasList);
    }
    
    public void ToggleFormulasList()
    {
        FormulasList.SetActive(!FormulasList.activeSelf);
    }
}
