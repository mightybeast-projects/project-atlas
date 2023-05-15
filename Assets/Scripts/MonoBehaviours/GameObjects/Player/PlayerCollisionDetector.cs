using Interfaces;
using MonoBehaviours.GameObjects.Enemy;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Player
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            AggroScript[] scripts = coll.gameObject.GetComponents<AggroScript>();
            
            foreach (var script in scripts)
                if (script != null && !script.isAggro)
                    script.isAggro = true;
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            IInteractable interactable = col.gameObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}