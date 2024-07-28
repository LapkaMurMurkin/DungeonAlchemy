using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public int BaseValue;
    public int ModifiedValue => CalculateModifiedValue();

    private readonly List<StatModifier> statModifiers;
    public readonly IList<StatModifier> StatModifiers;

    public Stat(int baseValue)
    {
        BaseValue = baseValue;
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    private int CalculateModifiedValue()
    {
        int flatModifierSum = 0;
        int percentModifierSum = 0;

        foreach (StatModifier modifier in statModifiers)
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
        statModifiers.Add(modifier);
    }

    public void RemoveModifier(StatModifier modifier)
    {
        statModifiers.Remove(modifier);
    }
}
