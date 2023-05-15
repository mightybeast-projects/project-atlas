using NaughtyAttributes;
using UnityEngine;

namespace Models.Value
{
    [CreateAssetMenu(menuName = "Value/IntValue")]
    public class IntValue : ScriptableObject
    {
        public int baseValue => _baseValue;
        
        public int value
        {
            get => _value;
            set => _value = value;
        }
        
        [SerializeField]
        private int _baseValue;
        [SerializeField][ReadOnly]
        private int _value;
    }
}