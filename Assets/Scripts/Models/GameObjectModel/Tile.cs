using UnityEngine;

namespace Models.GameObjectModel
{
    public class Tile
    {
        public int locationRatio { get; set; } = 50;
        public GameObject gameObject { get; set; }

        public Tile(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
