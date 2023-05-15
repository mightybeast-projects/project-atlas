using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class OpenPanelBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject _panel;
        
        private bool _panelOpened;

        public bool panelOpened => _panelOpened;

        public void OpenPanel()
        {
            ChangePanelStatus(!_panelOpened);
        }
        
        public void ChangePanelStatus(bool open)
        {
            _panel.SetActive(open);
            _panelOpened = open;
        }
    }
}