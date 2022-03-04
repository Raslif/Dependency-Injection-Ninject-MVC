using NInjectInMVC.Models.Abstract;

namespace NInjectInMVC.Models.Entity
{
    public class Connection : IConnection
    {
        private readonly string _connectionString = null;
        private readonly ConnectionDTO _connectionDTO = null;
        public Connection(string connectionString, string test, string data)
        {
            _connectionString = connectionString;
        }

        public Connection(string connectionString, ConnectionDTO connectionDTO)
        {
            _connectionDTO = connectionDTO;
            _connectionString = connectionString;
        }
        public string GetConnectionString()
        {
            var data = _connectionDTO;
            return _connectionString;
        }
    }
}