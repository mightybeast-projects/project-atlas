using EventSystem.Events;

namespace Managers.LocationManagers
{
    public class EnemyDeathHandler : LocationSubManager
    {
        public void HandleEnemyDeathAndRaise(VoidEvent eventToRaise)
        {
            if (_currentLocation.enemies.Count != 0) return;
            
            eventToRaise.Raise();
        }
    }
}