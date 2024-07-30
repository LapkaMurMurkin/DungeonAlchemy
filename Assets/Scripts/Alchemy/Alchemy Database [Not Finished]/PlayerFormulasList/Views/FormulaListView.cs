using UnityEngine;

public class FormulaListView : MonoBehaviour
{
    public FormulaListEntryView EntryViewPrefab;
    public Transform Container;

    public void Init(FormulasList list)
    {
        ClearContainer();
        list.Added += CreateSlot;
    }
    
    private void CreateSlot(FormulaListEntry entry)
    {
        var entryView = Instantiate(EntryViewPrefab, Container);
        entryView.Init(entry);
    }
    
    private void ClearContainer()
    {
        foreach (Transform child in Container)
            Destroy(child.gameObject);
    }
}
