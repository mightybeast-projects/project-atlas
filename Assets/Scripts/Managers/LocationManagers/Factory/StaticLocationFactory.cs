namespace Managers.LocationManagers.Factory
{
    public class StaticLocationFactory : LocationFactory
    {
        public override void GenerateLocation()
        {
            base.GenerateLocation();
            _contentPane.gameObject.SetActive(false);
        }
    }
}