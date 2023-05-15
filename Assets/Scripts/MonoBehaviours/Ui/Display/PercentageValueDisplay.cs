using Models.Value;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui.Display
{
    public class PercentageValueDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatValue _currentValue;
        [SerializeField]
        private FloatValue _maxValue;
        [SerializeField]
        private Text _valueText;
        
        private void Start()
        {
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            _valueText.text = $"{_currentValue.value / _maxValue.value * 100 : 0.00}" + "%";
        }
    }
}