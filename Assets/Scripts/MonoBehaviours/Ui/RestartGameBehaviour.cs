using EventSystem.Events;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class RestartGameBehaviour : MonoBehaviour
    {
        [SerializeField] private VoidEvent _onRestartGameEvent;
        
        public void RestartGame()
        {
            _onRestartGameEvent.Raise();
        }
    }
}