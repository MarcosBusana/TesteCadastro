namespace Infra.Data
{
    public interface IUnityOfWork
    {
        void BeginTransaction();
        int SaveAndCommit();
        int Save();
        void Commit();
        void Rollback();
    }
}
