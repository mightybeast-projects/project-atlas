using UnityEngine;

namespace MonoBehaviours
{
    public class DestroyComponent : MonoBehaviour
    {
        public void Destroy()
        {
            Debug.Log("+");
            Destroy(gameObject);
        }
    }
}