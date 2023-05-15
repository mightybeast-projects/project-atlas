using NaughtyAttributes;
using UnityEngine;

namespace Models.ItemDataModel
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField]
        protected string _name;
        public new string name => _name;

        [SerializeField][ShowAssetPreview]
        protected Sprite _sprite;
        public Sprite sprite => _sprite;
    }
}
