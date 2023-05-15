using Models;
using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/LocationEvent")]
    public class LocationEvent : BaseGameEvent<Location> { }
}