using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace JS.EventSystem
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        [SerializeField] private UnityEvent callbackEvent;

#pragma warning disable 0414
#if UNITY_EDITOR
        // Display notes field in the inspector.
        [Multiline, SerializeField]
        [FormerlySerializedAs("DeveloperNotes")]
        private string developerNotes = "";
#endif
#pragma warning restore 0414

        // Register and deregister events
        private void Awake() => gameEvent.RegisterListener(this);
        private void OnDestroy() => gameEvent.DeregisterListener(this);

        // Invoke event
        public void RaiseEvent() => callbackEvent.Invoke();
    }
}

