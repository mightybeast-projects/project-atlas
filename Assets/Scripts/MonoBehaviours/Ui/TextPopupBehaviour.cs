using TMPro;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class TextPopupBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _ySpeed = 0.5f;
        [SerializeField]
        private float _liveTime = 2f;
        [SerializeField]
        private float _alphaSpeed = 0.1f;
        
        private TextMeshPro _textMesh;
        private Color _textMeshColor;

        private void Awake()
        {
            _textMesh = transform.GetComponent<TextMeshPro>();
            _textMeshColor = _textMesh.color;
        }

        private void FixedUpdate()
        {
            transform.position += new Vector3(0, _ySpeed, 0);
            _liveTime -= Time.deltaTime;

            if (!(_liveTime <= 0)) return;
            
            _textMeshColor.a -= _alphaSpeed;
            _textMesh.color = _textMeshColor;
                
            if(_textMeshColor.a <= 0)
                Destroy(gameObject);
        }

        public void SetDamageAmount(string text)
        {
            _textMesh.SetText(text);
        }

        public void SetCrit(bool isCrit)
        {
            if (isCrit){
                _textMesh.color = Color.red;
                _textMesh.fontSize = 200;
            }
            _textMeshColor = _textMesh.color;
        }

        public void SetAttackDecoration(Color color)
        {
            _textMesh.color = color;
            _textMeshColor = _textMesh.color;
        }
    }
}