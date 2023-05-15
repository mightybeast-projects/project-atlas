using UnityEngine;

namespace Interfaces
{
    public interface IHittable
    {
        void GetHitFrom(GameObject hitSourceGameObject, int amount);
    }
}