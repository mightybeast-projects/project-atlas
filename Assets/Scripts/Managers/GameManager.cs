using System;
using System.Collections;
using Enums;
using EventSystem.Events;
using Managers.LocationManagers;
using MonoBehaviours.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static Vector3 worldOffset = new Vector3(-304, -164);
        public CharacterManager characterManager => _characterManager;
        public UiManager uIManager => _uiManager;

        [SerializeField]
        private LocationManager _locationManager;
        [SerializeField]
        private MapManager _mapManager;
        [SerializeField]
        private CharacterManager _characterManager;
        [SerializeField]
        private UiManager _uiManager;
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private VoidEvent _onGameRestarted;

        private static GameManager _INSTANCE;
        
        public static GameManager GetInstance()
        {
            return _INSTANCE;
        }
        
        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            CheckSingleton();
        }

        private void Start()
        {
            TeleportToLocationOf(_mapManager.homeLocationMapNode);
        }

        public void LoadNextLocation(WorldSide exitSide)
        {
            _mapManager.ChooseNextMapNode(exitSide);

            StartCoroutine(ConstructNextLocation());
        }

        public void TeleportToLocationOf(MapNodeBehaviour nextMapNode)
        {
            _mapManager.SetNextMapNodeAndConnection(nextMapNode, null);

            StartCoroutine(ConstructNextLocation());
        }
        
        public void StopGameWorld()
        {
            Time.timeScale = 0;
        }
        
        public void RestartGame()
        {
            Time.timeScale = 1;
            TeleportToLocationOf(_mapManager.homeLocationMapNode);
            _characterManager.ResetCharacterData();
            _mapManager.ResetNodesStatus();
            StartCoroutine(RaiseRestartedEvent());
        }
        
        private IEnumerator RaiseRestartedEvent()
        {
            yield return new WaitForSeconds(1f);
            _onGameRestarted.Raise();
        }
        
        private IEnumerator ConstructNextLocation()
        {
            _uiManager.FadeInLoadingScreen();

            yield return new WaitForSeconds(1f);
            InitializeNewLocation();

            _uiManager.FadeOutLoadingScreen();
        }

        private void InitializeNewLocation()
        {
            _locationManager.DestroyCurrentLocation();
            _locationManager.GetBiomeAndEndSideFrom(_mapManager.nextMapNode, _mapManager.nextConnection);
            _locationManager.CreateLocation();
            _mapManager.UpdateCurrentNodeAndMarker();
            _camera.transform.position = _characterManager.characterBehaviour.gameObject.transform.position;
        }

        private void CheckSingleton()
        {
            if (_INSTANCE == null)
                _INSTANCE = this;
            else if (_INSTANCE == this)
                Destroy(gameObject);
        }
    }
}
