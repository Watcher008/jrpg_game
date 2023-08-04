using UnityEngine;

namespace JS.EventSystem
{
    /// <summary>
    /// Logs all events to the console.
    /// </summary>
    public class EventLogger : MonoBehaviour
    {
        [SerializeField] private bool logEvents;
        /// <summary>
        /// Debugging tool - Raise an assertion alert if event is triggered.
        /// </summary>
        [Header("*Optional")]
        [SerializeField] private GameEvent watchForEvent;

        /// <summary>
        /// Register event.
        /// </summary>
        private void OnEnable()
        {
            GameEvent.AnyEventRaised += LogEvent;
        }

        /// <summary>
        /// Deregister event.
        /// </summary>
        private void OnDisable()
        {
            GameEvent.AnyEventRaised -= LogEvent;
        }

        /// <summary>
        /// Log event to console.
        /// </summary>
        /// <param name="e">GameEvent to log.</param>
        private void LogEvent(GameEvent e)
        {
            if (!logEvents) return;

            if (watchForEvent != null && e.name.Equals(watchForEvent.name))
            {
                Debug.LogAssertion(e.name);
                return;
            }

            Debug.Log(e.name);
        }
    }
}