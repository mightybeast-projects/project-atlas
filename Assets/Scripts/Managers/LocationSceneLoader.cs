using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LocationSceneLoader : MonoBehaviour
    { 
        public void LoadLocationScene(string locationSceneName)
        {
            SceneManager.LoadScene(locationSceneName);
        }
    }
}