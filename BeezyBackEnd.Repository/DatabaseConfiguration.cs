using Microsoft.Extensions.Configuration;

namespace BeezyBackEnd.Repository
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private string DataConnectionKey = "DbConnectionString";

        //private string AuthConnectionKey = "onionAuthConnection";

        public string GetDataConnectionString()
        {
            return GetConfiguration().GetConnectionString(DataConnectionKey);
        }

        //public string GetAuthConnectionString()
        //{
        //    return GetConfiguration().GetConnectionString(AuthConnectionKey);
        //}
    }
}