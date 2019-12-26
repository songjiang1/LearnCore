namespace Learn.Bll.Repository
{
    public class RepositoryFactory<T> where T : class, new()
    {
        public Repository BaseRepository()
        {
            return new Repository(DbFactory.Base());
        }
    }
}
