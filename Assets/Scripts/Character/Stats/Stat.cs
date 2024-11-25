using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public int BaseValue;
    public int ModifiedValue => CalculateModifiedValue();

    private readonly List<StatModifier> _statModifiers;
    public readonly IList<StatModifier> StatModifiers;

    public Stat(int baseValue)
    {
        BaseValue = baseValue;
        _statModifiers = new List<StatModifier>();
        StatModifiers = _statModifiers.AsReadOnly();
    }

    private int CalculateModifiedValue()
    {
        int flatModifierSum = 0;
        int percentModifierSum = 0;

        foreach (StatModifier modifier in _statModifiers)
        {
            if (modifier.Type == StatModifierType.Flat)
                flatModifierSum += modifier.Value;

            if (modifier.Type == StatModifierType.Percent)
                percentModifierSum += modifier.Value;
        }

        return BaseValue + flatModifierSum + BaseValue * percentModifierSum;
    }

    public void AddModifier(StatModifier modifier)
    {
        _statModifiers.Add(modifier);
    }

    public void RemoveModifier(StatModifier modifier)
    {
        _statModifiers.Remove(modifier);
    }
}
