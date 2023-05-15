using System.Collections.Generic;
using EventSystem.Events;
using Managers;
using Models.StatModel;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui
{
    public class GameClassNodeBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameClassData _gameClassData;
        [SerializeField]
        private Image _imageObject;
        [SerializeField]
        private Material _grayscaleMaterial;
        [SerializeField]
        private bool _unlocked;
        [SerializeField]
        private GameObject _unlockedNodeImage;
        [SerializeField]
        private CharacterScript _characterScript;
        [SerializeField]
        private VoidEvent _onClassNodeUnlocked;
    
        private GameObject _treeNodesParent;
        private GameObject _descriptionPanel;
        private GameObject _unlockButton;
        private Text _affixDescription;
        private Text _className;
    
        private bool _descriptionPanelOpened;

        private void Start()
        {
            _treeNodesParent = transform.parent.gameObject;
            _descriptionPanel = transform.Find("DescriptionPanel").gameObject;

            _affixDescription = transform.Find("DescriptionPanel/AffixDescriptionPanel/AffixDescription").
                gameObject.GetComponent<Text>();
            _className = transform.Find("DescriptionPanel/ClassNamePanel/ClassName").
                gameObject.GetComponent<Text>();
            _unlockButton = transform.Find("DescriptionPanel/UnlockButton").gameObject;
        
            _affixDescription.text = _gameClassData.affix != null ? _gameClassData.affix.GetBasicDescription() : "";
            _className.text = _gameClassData.name;
        }

        private void OnValidate()
        {
            try { UpdateNodeVisuals(); }
            catch { }
        }
        
        public void ShowDescription()
        {
            if(!_descriptionPanelOpened)
                OpenDescriptionPanel();
            else
                CloseDescriptionPanel();
        
            UpdateUnlockButton();
        }
        
        public void CloseDescriptionPanel()
        {
            _descriptionPanel.SetActive(false);
            _descriptionPanelOpened = false;
        }

        public void Unlock()
        {
            _characterScript.classPoints.value--;
            _unlocked = true;
            UpdateUnlockedNodeImage();
            UpdateAllUnlockButtons();
            _gameClassData.affix.ApplyTo(GameManager.GetInstance().characterManager.characterBehaviour.character);
            
            _onClassNodeUnlocked.Raise();
        }
        
        public void ResetNodeStatus()
        {
            _unlocked = false;
            UpdateUnlockedNodeImage();
        }

        private void UpdateNodeVisuals()
        {
            _imageObject.sprite = _gameClassData.sprite;
            name = _gameClassData.name;

            if (_gameClassData == null)
                _imageObject.sprite = null;

            UpdateUnlockedNodeImage();
        }
        
        private void UpdateUnlockButton()
        {
            if(!CanUnlock())
                _unlockButton.SetActive(false);
            else if(CanUnlock())
                _unlockButton.SetActive(true);
        }
        
        private bool CanUnlock()
        {
            return ParentsUnlocked() && _characterScript.classPoints.value > 0 && !_unlocked;
        }

        private void OpenDescriptionPanel()
        {
            _descriptionPanel.SetActive(true);
            _descriptionPanelOpened = true;
        }

        private bool ParentsUnlocked()
        {
            bool parentsUnlocked = true;
        
            List<GameClassData> gameClassDates = _gameClassData.parentDatas;
            foreach (GameClassData data in gameClassDates)
            {
                GameObject gameClassNode = _treeNodesParent.transform.Find(data.name).gameObject;
                GameClassNodeBehaviour parentNode = gameClassNode.GetComponent<GameClassNodeBehaviour>();
                
                if (parentNode._unlocked) continue;
                
                parentsUnlocked = false;
                break;
            }
        
            return parentsUnlocked;
        }
    
        private void UpdateAllUnlockButtons()
        {
            foreach (Transform child in _treeNodesParent.transform)
            {
                GameClassNodeBehaviour node = child.GetComponent<GameClassNodeBehaviour>();
                node.UpdateUnlockButton();
            }
        }
    
        private void UpdateUnlockedNodeImage()
        {
            if (_unlocked)
            {
                _imageObject.material = null;
                _unlockedNodeImage.SetActive(true);
            }
            else
            {
                _imageObject.material = _grayscaleMaterial;
                _unlockedNodeImage.SetActive(false);
            }
        }
    }
}