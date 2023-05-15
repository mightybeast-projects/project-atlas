using System.Collections;
using EventSystem.Events;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Managers.LocationManagers
{
    public class LootManager : LocationSubManager
    {
        [SerializeField]
        private VoidEvent _onPlayerExperienceChanged;
        [SerializeField]
        private int _experienceAmountOnKill = 20;
        private int _experiencePool;
        
        public void AddExperience()
        {
            _experiencePool += _experienceAmountOnKill;
        }
        
        public void RewardPlayerWithExp()
        {
            StartCoroutine(GiveReward());
        }

        private IEnumerator GiveReward()
        {
            yield return new WaitForSeconds(0.1f);
            
            CharacterScript script = GameManager.GetInstance().characterManager.characterBehaviour;
            script.AddExperience(_experiencePool);
            _experiencePool = 0;
            
            _onPlayerExperienceChanged.Raise();
        }
    }
}