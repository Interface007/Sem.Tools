using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sem.Data.SprocAccess.SqlServer
{
    public class SqlReader : IReader
    {
        private readonly SqlDataReader sqlDataReader;

        public SqlReader(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader;
        }

        public Task<bool> Read()
        {
            return this.sqlDataReader.ReadAsync();
        }

        public Task<T> Get<T>(int index)
        {
            return this.sqlDataReader.GetFieldValueAsync<T>(index);
        }

        public Task NextResult()
        {
            return this.sqlDataReader.NextResultAsync();
        }

        public Task Close()
        {
            return this.sqlDataReader.CloseAsync();
        }
    }
}