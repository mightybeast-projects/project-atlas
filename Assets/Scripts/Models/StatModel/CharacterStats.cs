using System.Collections.Generic;
using UnityEngine;

namespace Models.StatModel
{
    [CreateAssetMenu(menuName = "Player/PlayerStats")]
    public class CharacterStats : ScriptableObject
    {
        public List<CharacterStat> statList = new List<CharacterStat>();
    }
}