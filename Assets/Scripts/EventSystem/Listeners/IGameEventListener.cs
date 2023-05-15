namespace EventSystem.Listeners
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T t);
    }
}