using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Character Stat Data")]
public class CharacterStatData : ScriptableObject
{
    public int defaultHealth;
    public int defaultMana;
    public int defaultPower;
    public int defaultAccuracy;
    public int defaultMagic;
    public int defaultEvasion;
    public int defaultDefense;
    public int defaultMagicDefense;
    public int defaultSpeed;
}
