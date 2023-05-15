using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class SetCanvasCameraBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;
        
        public void SetCamera(Camera newCamera)
        {
            Debug.Log("+");
            _canvas.worldCamera = newCamera;
        }
    }
}