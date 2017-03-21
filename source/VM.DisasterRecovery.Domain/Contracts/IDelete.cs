namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IDelete<TEntity>
    {
        bool Deleted { get; }

        void Delete();
    }
}