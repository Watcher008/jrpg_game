using JS.EventSystem;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent triggerCombatEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        triggerCombatEvent.Invoke();
    }
}
