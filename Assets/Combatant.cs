using System;
using UnityEngine;

public class Combatant : MonoBehaviour, IComparable<Combatant>
{
    private CharacterStats stats;
    public CharacterStats Stats
    {
        get
        {
            if(stats == null)
            {
                stats = GetComponent<CharacterStats>();
            }
            return stats;
        }
    }

    public int CompareTo(Combatant other)
    {
        if (Stats.Attributes.Speed.Value < other.Stats.Attributes.Speed.Value) return -1;
        if (Stats.Attributes.Speed.Value > other.Stats.Attributes.Speed.Value) return 1;
        return 0;
    }
}
