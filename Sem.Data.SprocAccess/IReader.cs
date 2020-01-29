namespace Sem.Data.SprocAccess
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Simple data reader interface with only the needed methods to
    /// provide an interface that can easily be implemented.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Advances to the next record.
        /// </summary>
        /// <returns>A value indicating whether there is still data to be read.</returns>
        Task<bool> Read();

        /// <summary>
        /// Reads the value of a column by its index.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="index">The column index.</param>
        /// <returns>The value of the column in the current row.</returns>
        Task<T> Get<T>(int index);

        /// <summary>
        /// Reads the value of a column by its index.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <param name="type">The type of the result.</param>
        /// <returns>The value of the column in the current row.</returns>
        Task<object> Get(int index, Type type);

        /// <summary>
        /// Advances to the next result set.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        Task NextResult();

        /// <summary>
        /// Closes the reader.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        Task Close();

        /// <summary>
        /// Gets the index of a column by its name (case-insensitive).
        /// When there are two columns with the same name, the first index will be returned.
        /// </summary>
        /// <param name="columnName">The name of the column to search.</param>
        /// <returns>The index of the column.</returns>
        int IndexByName(string columnName);
    }
}
