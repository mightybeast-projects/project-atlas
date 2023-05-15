using Enums;
using Managers;
using Models.MapModel;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui
{
    public class MapNodeBehaviour: MonoBehaviour
    {
        public MapNodeStatus mapNodeStatus
        {
            get => _mapNodeStatus;
            set => _mapNodeStatus = value;
        }

        public MapNodeData mapNodeData => _mapNodeData;
        public bool cleared
        {
            get => _cleared;
            set => _cleared = value;
        }

        [SerializeField]
        private Image _nodeImage;
        [SerializeField]
        private MapNodeStatus _mapNodeStatus = MapNodeStatus.LOCKED;
        [SerializeField]
        private MapNodeData _mapNodeData;
        [SerializeField]
        private bool _cleared;

        private void OnEnable()
        {
            Sprite mapNodeSprite = null;
            
            switch (_mapNodeStatus)
            {
                case MapNodeStatus.LOCKED:
                    mapNodeSprite = Resources.Load<Sprite>("Sprites/Ui/Map/map_node_locked");
                    break;
                case MapNodeStatus.UNLOCKED:
                    mapNodeSprite = Resources.Load<Sprite>("Sprites/Ui/Map/map_node_unlocked");
                    break;
                case MapNodeStatus.UNLOCKED_PORTAL:
                    mapNodeSprite = Resources.Load<Sprite>("Sprites/Ui/Map/map_node_unlocked_portal");
                    AddButtonListener();
                    break;
            }

            _nodeImage.sprite = mapNodeSprite;
        }

        public void Unlock()
        {
            _mapNodeStatus = MapNodeStatus.UNLOCKED;
        }

        public void UnlockPortal()
        {
            _mapNodeStatus = MapNodeStatus.UNLOCKED_PORTAL;

            AddButtonListener();
        }

        private void AddButtonListener()
        {
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveListener(TeleportToThisNode);
            button.onClick.AddListener(TeleportToThisNode);
        }

        private void TeleportToThisNode()
        {
            GameManager gameManager = GameManager.GetInstance();
            gameManager.TeleportToLocationOf(this);
        }
    }
}
