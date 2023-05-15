using Models;
using UnityEngine;

namespace Managers.LocationManagers
{
    public abstract class LocationSubManager : MonoBehaviour
    {
        [SerializeField] protected Transform _contentPane;
        
        protected Location _currentLocation;

        public void SetCurrentLocation(Location receivedLocation)
        {
            _currentLocation = receivedLocation;
        }
    }
}