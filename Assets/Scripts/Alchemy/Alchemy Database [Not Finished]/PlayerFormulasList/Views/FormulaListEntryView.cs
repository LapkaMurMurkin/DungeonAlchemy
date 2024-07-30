using UnityEngine;
using UnityEngine.UI;

public class FormulaListEntryView : MonoBehaviour
{
    public Image EntryImage;
    public Button Button;
    
    private FormulaListEntry _entry;

    public void Init(FormulaListEntry entry)
    {
        _entry = entry;
        EntryImage.sprite = _entry.Formula.Potion.Sprite;
        Button.onClick.AddListener(SelectThis);
    }

    private void SelectThis()
    {
        ServiceLocator.Get<FormulaSelector>().CurrentFormulaEntry.Value = _entry;
    }
}
