using R3;

public class FormulaSelector
{
    public ReactiveProperty<FormulaListEntry> CurrentFormulaEntry { get; private set; } = new ReactiveProperty<FormulaListEntry>();
    private FormulasList _formulasList;

    public void Init(FormulasList list)
    {
        _formulasList = list;
        CurrentFormulaEntry.Value = _formulasList.Get(0);
    }
}
