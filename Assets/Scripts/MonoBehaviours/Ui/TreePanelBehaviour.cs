using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class TreePanelBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform _treeNodes;

        private void OnDisable()
        {
            HideNodeDescriptions();
        }
        
        private void HideNodeDescriptions()
        {
            foreach (Transform child in _treeNodes)
            {
                GameClassNodeBehaviour nodeBehaviour = child.GetComponent<GameClassNodeBehaviour>();
                nodeBehaviour.CloseDescriptionPanel();
            }
        }
    }
}