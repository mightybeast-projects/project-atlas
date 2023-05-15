using NaughtyAttributes;
using UnityEngine;

namespace Models.Value
{
    [CreateAssetMenu(menuName = "Value/FloatValue")]
    public class FloatValue : ScriptableObject
    {
        public float baseValue => _baseValue;

        public float value
        {
            get => _value;
            set => _value = value;
        }
        
        [SerializeField]
        private float _baseValue;
        [SerializeField]
        private bool _editValue;
        [SerializeField][EnableIf("_editValue")]
        private float _value;
    }
}