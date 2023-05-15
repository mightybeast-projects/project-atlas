using Enums;
using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/LocationExitEvent")]
    public class LocationExitEvent : BaseGameEvent<WorldSide> { }
}