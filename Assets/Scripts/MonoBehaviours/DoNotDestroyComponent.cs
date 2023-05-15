using UnityEngine;

namespace MonoBehaviours
{
    public class DoNotDestroyComponent : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}