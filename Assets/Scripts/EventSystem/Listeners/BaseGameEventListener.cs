using EventSystem.Events;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem.Listeners
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> 
        where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        public E gameEvent
        {
            get => _gameEvent;
            set => _gameEvent = value;
        }
        
        [SerializeField]
        private E _gameEvent;
        
        // ReSharper disable once Unity.RedundantSerializeFieldAttribute
        [SerializeField]
        private UER _unityEventResponse;

        private void OnEnable()
        {
            if(_gameEvent == null) return;
            
            _gameEvent.RegisterListener(this);
        }
        
        private void OnDisable()
        {
            if(_gameEvent == null) return;
            
            _gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T t)
        {
            _unityEventResponse?.Invoke(t);
        }
    }
}