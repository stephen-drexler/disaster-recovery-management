namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IPublish<T>
    {
        bool Published { get; }

        void Publish();

        void UnPublish();
    }
}