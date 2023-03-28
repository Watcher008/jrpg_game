using UnityEngine;

[CreateAssetMenu(fileName = "New Generic Item", menuName = "Scriptable Objects/Items/Generic")]
public class ItemBase : ScriptableObject
{
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public Sprite ItemIcon { get; private set; }
    [field: SerializeField] public float ItemWeight { get; private set; }
    [field: SerializeField] public float ItemValue { get; private set; }
    [field: SerializeField] public bool CanStack { get; private set; }
}
