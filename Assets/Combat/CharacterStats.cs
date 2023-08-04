using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public delegate void OnHealthChangeCallback();
    public OnHealthChangeCallback onDamageTaken;

    [SerializeField] private CharacterStatData stats;
    [SerializeField] private CharacterAttributes attributes;
    public CharacterAttributes Attributes => attributes;

    [field: SerializeField] public int currentHealth { get; private set; }
    [field: SerializeField] public int currentMana { get; private set; }

    private void Start()
    {
        SetInitialStatValues();

        currentHealth = attributes.Health.Value;
        currentMana = attributes.Mana.Value;
    }

    private void SetInitialStatValues()
    {
        attributes.Health.SetBaseValue(stats.defaultHealth);
        attributes.Mana.SetBaseValue(stats.defaultMana);
        attributes.Power.SetBaseValue(stats.defaultPower);
        attributes.Accuracy.SetBaseValue(stats.defaultAccuracy);
        attributes.Magic.SetBaseValue(stats.defaultMagic);
        attributes.Evasion.SetBaseValue(stats.defaultEvasion);
        attributes.Defense.SetBaseValue(stats.defaultDefense);
        attributes.MagicDefense.SetBaseValue(stats.defaultMagicDefense);
        attributes.Speed.SetBaseValue(stats.defaultSpeed);
    }

    public void OnTakeDamage(int value)
    {
        currentHealth -= value;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath();
        }

        onDamageTaken?.Invoke();
    }

    public void OnDeath()
    {
        Debug.Log(transform.name + " has died");
    }

    public void OnRestoreHealth(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, attributes.Health.Value);
    }
}