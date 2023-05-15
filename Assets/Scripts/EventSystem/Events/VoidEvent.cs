using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/VoidEvent")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}