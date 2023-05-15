using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy
{
    public abstract class AggroScript : MonoBehaviour
    {
        public bool isAggro
        {
            get => _isAggro;
            set => _isAggro = value;
        }
        
        protected bool _isAggro;
    }
}