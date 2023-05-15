using System;
using Models.Value;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui.Display
{
    public class IntValueDisplay : MonoBehaviour
    {
        [SerializeField]
        private IntValue _intValue;
        [SerializeField]
        private Text _valueText;

        private void Start()
        {
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            _valueText.text = _intValue.value.ToString();
        }
    }
}