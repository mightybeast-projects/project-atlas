using System.Globalization;
using Models.Value;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui.Display
{
    public class FloatValueDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatValue _floatValue;
        [SerializeField]
        private Text _valueText;
        
        private void Start()
        {
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            _valueText.text = _floatValue.value.ToString(CultureInfo.CurrentCulture);
        }
    }
}