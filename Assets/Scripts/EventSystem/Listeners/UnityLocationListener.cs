using EventSystem.Events;
using EventSystem.UnityEvents;
using Models;

namespace EventSystem.Listeners
{
    public class UnityLocationListener : BaseGameEventListener<Location, LocationEvent, UnityLocationEvent> { }
}