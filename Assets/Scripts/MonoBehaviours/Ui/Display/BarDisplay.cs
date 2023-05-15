using Models.Value;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui.Display
{
    public class BarDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatValue _currentValue;
        [SerializeField]
        private FloatValue _maxValue;
        [SerializeField]
        private Image _barImage;
        
        private void Start()
        {
            UpdateDisplay();
        }
        
        public void UpdateDisplay()
        {
            var fillAmount = _currentValue.value / _maxValue.value;
            _barImage.fillAmount = fillAmount;
        }
    }
}