namespace Assets.Resources.Services.EventAggregator
{
    public interface IListener<T>
    {
        void Handle(T message);
    }
}