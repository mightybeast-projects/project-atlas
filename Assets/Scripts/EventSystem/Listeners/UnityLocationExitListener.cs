using Enums;
using EventSystem.Events;
using EventSystem.UnityEvents;

namespace EventSystem.Listeners
{
    public class UnityLocationExitListener : 
        BaseGameEventListener<WorldSide, LocationExitEvent, UnityLocationExitEvent> { }
}