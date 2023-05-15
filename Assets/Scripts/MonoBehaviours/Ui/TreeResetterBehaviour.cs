using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class TreeResetterBehaviour : MonoBehaviour
    {
        [SerializeField] private List<GameClassNodeBehaviour> _nodes;
        
        public void ResetNodes()
        {
            foreach (GameClassNodeBehaviour node in _nodes)
                node.ResetNodeStatus();
        }
    }
}