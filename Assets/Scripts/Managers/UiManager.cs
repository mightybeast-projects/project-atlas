using System.Collections;
using MonoBehaviours.GameObjects.Player;
using MonoBehaviours.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private OpenPanelBehaviour _mapButtonScript;
        [SerializeField]
        private Image _loadingScreen;
        [SerializeField]
        private GameObject _damagePopupPrefab;
        [SerializeField]
        private CharacterScript _player;
        [SerializeField]
        private GameObject _gameOverScreen;
        [SerializeField]
        private GameObject _victoryScreen;

        private void Start()
        {
            _loadingScreen.gameObject.SetActive(true);
        }
        
        public void FadeInLoadingScreen()
        {
            if(_loadingScreen.IsActive())
                return;

            StartCoroutine(IncreaseAlpha());
        }

        public void FadeOutLoadingScreen()
        {
            if(!_loadingScreen.IsActive())
                return;
            
            StartCoroutine(DecreaseAlpha());
        }

        public void CreateDamagePopup(Vector3 position, int amount, bool isCrit, Color color)
        {
            GameObject damagePopup = Instantiate(_damagePopupPrefab, position, Quaternion.identity);
            TextPopupBehaviour textScript = damagePopup.GetComponent<TextPopupBehaviour>();
            textScript.SetDamageAmount(amount.ToString());
            textScript.SetAttackDecoration(color);
            textScript.SetCrit(isCrit);
        }
        
        public void CreateTextPopup(Vector3 position, string text, Color color)
        {
            InitializeNewTextPopup(position, text, color);
        }
        
        public void CreateLevelUpTextPopup()
        {
            InitializeNewTextPopup(_player.transform.position, "Level up!", Color.green);
        }
        
        public void ChangeGameOverScreenState(bool state)
        {
            _gameOverScreen.SetActive(state);
        }
        
        public void ShowVictoryScreen()
        {
            _victoryScreen.SetActive(true);
        }

        private void InitializeNewTextPopup(Vector3 position, string text, Color color)
        {
            GameObject damagePopup = Instantiate(_damagePopupPrefab, position, Quaternion.identity);
            TextPopupBehaviour textScript = damagePopup.GetComponent<TextPopupBehaviour>();
            textScript.SetDamageAmount(text);
            textScript.SetAttackDecoration(color);
        }

        public void OpenMapPanel()
        {
            if(!_mapButtonScript.panelOpened)
                _mapButtonScript.ChangePanelStatus(true);
        }
        
        public void CloseMapPanel()
        {
            if(_mapButtonScript.panelOpened)
                _mapButtonScript.ChangePanelStatus(false);
        }
        
        private IEnumerator IncreaseAlpha()
        {
            _loadingScreen.gameObject.SetActive(true);
            for (float i = 0; i <= 1; i += Time.deltaTime * 3)
            {
                _loadingScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }

            _loadingScreen.color = new Color(0, 0, 0, 1);
        }
        
        private IEnumerator DecreaseAlpha()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime * 3)
            {
                _loadingScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }

            _loadingScreen.color = new Color(0, 0, 0, 0);
            _loadingScreen.gameObject.SetActive(false);
            
            yield return new WaitForSeconds(6);
        }
    }
}