using System;
using System.Collections.Generic;
using Enums;
using EventSystem.Events;
using Models;
using Models.ItemDataModel;
using UnityEngine;

namespace Managers
{
    public class PrismStonesManager : MonoBehaviour
    {
        [SerializeField] private VoidEvent _onFinalPrismStonePickedUp;
        [SerializeField] private List<PrismStoneCompletion> _prismStoneCompletions;

        private PrismStoneCompletion _prismStoneCompletion;
        private Biome _currentBiome;
        
        public PrismStone GetCurrentPrismStone()
        {
            GetCurrentCompletion();
            return _prismStoneCompletion.obtained ? null : _prismStoneCompletion.prismStone;
        }
        
        public void GetCurrentLocationBiome(Location createdLocation)
        {
            _currentBiome = createdLocation.biome;
        }
        
        public void ObtainCurrentBiomePrismStone()
        {
            _prismStoneCompletion.obtained = true;
            
            if(AllPrismStonesCollected())
                _onFinalPrismStonePickedUp.Raise();
        }
        
        public void ResetPrismStoneCompletions()
        {
            foreach (PrismStoneCompletion completion in _prismStoneCompletions)
                completion.obtained = false;
        }
        
        private bool AllPrismStonesCollected()
        {
            foreach (PrismStoneCompletion prismStoneCompletion in _prismStoneCompletions)
                if(!prismStoneCompletion.obtained) return false;
            
            return true;
        }
        
        private void GetCurrentCompletion()
        {
            foreach (PrismStoneCompletion _currentCompletion in _prismStoneCompletions)
                if (_currentCompletion.prismStone.biome == _currentBiome)
                    _prismStoneCompletion = _currentCompletion;
        }
        
        [Serializable]
        private class PrismStoneCompletion
        {
            public PrismStone prismStone => _prismStone;
            public bool obtained
            {
                get => _obtained;
                set => _obtained = value;
            }

            [SerializeField]
            private PrismStone _prismStone;

            [SerializeField]
            private bool _obtained;
        }

        
    }
}