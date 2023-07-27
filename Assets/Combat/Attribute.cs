using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [SerializeField] private Attribute attribute;
    [SerializeField] private int baseValue;
    public int BaseValue => baseValue;
    public int Value => GetValue();

    private List<int> modifiers = new List<int>();

    public void SetBaseValue(int value)
    {
        baseValue = value;
    }

    private int GetValue()
    {
        int modifiedValue = baseValue;
        for (int i = 0; i < modifiers.Count; i++)
        {
            modifiedValue += modifiers[i];
        }
        return modifiedValue;
    }

    public void AddModifier(int value)
    {
        if (value == 0) return;
        modifiers.Add(value);
    }

    public void RemoveModifier(int value)
    {
        if (value == 0) return;
        modifiers.Remove(value);
    }
}