using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui.Display
{
    public class EnemyBarBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Image _barImage;
        [SerializeField]
        private float _currentValue;
        [SerializeField]
        private float _maxValue;

        public void UpdateValues(int currentValue, int maxValue)
        {
            _currentValue = currentValue;
            _maxValue = maxValue;
        }
    
        private void FixedUpdate()
        {
            UpdateUi();
        }

        private void UpdateUi()
        {
            if (_barImage == null) return;
            
            var fillAmount = _currentValue / _maxValue;
            _barImage.fillAmount = fillAmount;
        }
    }
}
