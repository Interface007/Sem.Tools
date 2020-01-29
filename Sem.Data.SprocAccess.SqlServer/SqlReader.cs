namespace Sem.Data.SprocAccess.SqlServer
{
    using System;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Threading.Tasks;

    /// <summary>
    /// SQL serer implementation of the reader interface <see cref="IReader"/>.
    /// </summary>
    public class SqlReader : IReader
    {
        private readonly SqlDataReader sqlDataReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlReader"/> class.
        /// </summary>
        /// <param name="sqlDataReader">The data reader to read from.</param>
        public SqlReader(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader;
        }

        /// <inheritdoc />
        public Task<bool> Read()
        {
            return this.sqlDataReader.ReadAsync();
        }

        /// <inheritdoc />
        public Task<T> Get<T>(int index)
        {
            return this.sqlDataReader.GetFieldValueAsync<T>(index);
        }

        /// <inheritdoc />
        public Task<object> Get(int index, Type type)
        {
            return Task.FromResult(Convert.ChangeType(this.sqlDataReader.GetValue(index), type, CultureInfo.InvariantCulture));
        }

        /// <inheritdoc />
        public Task NextResult()
        {
            return this.sqlDataReader.NextResultAsync();
        }

        /// <inheritdoc />
        public Task Close()
        {
            return this.sqlDataReader.CloseAsync();
        }

        /// <inheritdoc />
        public int IndexByName(string columnName)
        {
            return this.sqlDataReader.GetOrdinal(columnName);
        }
    }
}