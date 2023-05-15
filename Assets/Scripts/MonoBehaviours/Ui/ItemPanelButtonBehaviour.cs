using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui
{
    public class ItemPanelButtonBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform _panelToShow;
        [SerializeField]
        private Vector3 _pointToShow;
        [SerializeField]
        private Vector3 _pointToHide;
        
        private Transform _buttonTransform;
        private Vector3 _destinationPoint;
        private Button _button;
        private bool _isVisible;

        private void Start()
        {
            _buttonTransform = transform;
            _button = GetComponent<Button>();
        }

        public void UpdatePanelStatus()
        {
            if(!_isVisible)
                _destinationPoint = _pointToShow + _panelToShow.position;
            else
                _destinationPoint = _pointToHide + _panelToShow.position;

            _panelToShow.position = _destinationPoint;
            _buttonTransform.Rotate(0, 0, -180);
            _isVisible = !_isVisible;
        }
        
        public void ShowBriefly()
        {
            _button.enabled = false;
            
            _panelToShow.position = _pointToShow + _panelToShow.position;
            
            StartCoroutine(HidePanelWithTimeout());
        }
        
        private IEnumerator HidePanelWithTimeout()
        {
            yield return new WaitForSeconds(2f);
            
            _panelToShow.position = _pointToHide + _panelToShow.position;
            
            _button.enabled = true;
        }
    }
}