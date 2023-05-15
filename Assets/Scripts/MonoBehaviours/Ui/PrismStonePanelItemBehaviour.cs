using Models.ItemDataModel;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class PrismStonePanelItemBehaviour : MonoBehaviour
    {
        public PrismStone prismStone => _prismStone;
        
        [SerializeField]
        private PrismStone _prismStone;
    }
}