using System.Collections.Generic;
using Enums;
using Interfaces;
using Managers;
using Models.GameObjectModel;
using Models.StatModel;
using MonoBehaviours.GameObjects.Player;
using MonoBehaviours.Ui;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MonoBehaviours.GameObjects
{
    public class WeaponScript : MonoBehaviour
    {
        [SerializeField]
        private CharacterScript _characterScript;
        [SerializeField]
        private CameraScript _cameraScript;
        [SerializeField]
        private Transform _characterTransform;
        [SerializeField]
        private List<CharacterAttackStat> _attackCharacterStats;

        private Character _character;
        private CharacterAttackStat _highestCharacterAttackStat;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject == _characterTransform.gameObject) return;
            
            ChooseAttackStat();
            
            CharacterStat critStat = _characterScript.character.GetCharacterStat(StatType.CRIT_CHANCE);
            
            bool criticalHit = Random.Range(0.01f, 1f) <= critStat.statValue.value / 100;
            int attackAmount = (int) (_highestCharacterAttackStat.statValue.value * (criticalHit? 1.5f : 1f));

            DealDamage(coll, criticalHit, attackAmount);
        }

        private void ChooseAttackStat()
        {
            _highestCharacterAttackStat = _attackCharacterStats[0];
            foreach (CharacterAttackStat stat in _attackCharacterStats)
                if(stat.statValue.value > _highestCharacterAttackStat.statValue.value)
                    _highestCharacterAttackStat = stat;
        }

        private void DealDamage(Collider2D coll, bool criticalHit, int attackAmount)
        {
            IHittable hittableObject = coll.gameObject.GetComponent<IHittable>();
            if (hittableObject == null) return;
            
            if (criticalHit)
            {
                StartCoroutine(_cameraScript.Shake(0.1f, 3f));
                hittableObject.GetHitFrom(_characterTransform.gameObject, attackAmount);
            }
            else
                hittableObject.GetHitFrom(_characterTransform.gameObject, attackAmount);

            GameManager.GetInstance().uIManager.
                CreateDamagePopup(coll.gameObject.transform.position + new Vector3(-7, 40, 0), 
                    attackAmount, criticalHit, _highestCharacterAttackStat.attackColor);
        }
    }
}
