namespace WebAppDapper.Models
{
    public abstract class BaseRepository
    {
        protected string ConnectionString;
        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Store2") ??
                                throw new ArgumentNullException("Connection string 'Store2' not found in configuration.");
        }

    }
}
