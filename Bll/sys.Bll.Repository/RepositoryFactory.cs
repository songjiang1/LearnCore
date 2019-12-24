namespace Learn.Bll.Repository
{
    public class RepositoryFactory
    {
        public Repository BaseRepository()
        {
            return new Repository(DbFactory.Base());
        }
    }
}
