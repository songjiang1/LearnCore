namespace Learn.Bll.Repository
{
    public class RepositoryFactory<T> where T : class, new()
    {
        public Repository<T> BaseRepository()
        { 
            return new Repository<T>(DbFactory.Base());
        }
    }
}
