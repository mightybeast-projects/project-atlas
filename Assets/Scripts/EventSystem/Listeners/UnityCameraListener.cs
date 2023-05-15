using EventSystem.Events;
using EventSystem.UnityEvents;
using Models;
using UnityEngine;

namespace EventSystem.Listeners
{
    public class UnityCameraListener : BaseGameEventListener<Camera, CameraEvent, UnityCameraEvent> { }
}