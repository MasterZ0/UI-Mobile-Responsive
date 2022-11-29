using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace TritanTest.Shared
{
    /// <summary>
    /// Easy to call a Unity Event
    /// </summary>
    public class AnimationEventTrigger : MonoBehaviour
    {
        [Serializable]
        public struct EventReference
        {
            public string eventName;
            public UnityEvent unityEvent;
        }

        [Header("Event Trigger")]
        [SerializeField] private EventReference[] eventReferences;

        public void OnEvent(string eventName)
        {
            EventReference reference = eventReferences.First(e => e.eventName == eventName);
            reference.unityEvent.Invoke(); 
        }
    }
}
