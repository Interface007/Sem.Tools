namespace Sem.Data.SprocAccess.FileSystemTests
{
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class that implements a slow, bt generic mapper method.
    /// </summary>
    public static class Map
    {
        /// <summary>
        /// Mapper method that maps data from an <see cref="IReader"/> to a POCO object using the
        /// names of the properties. The process uses a very simple reflection based approach, that
        /// is not really "production ready" - use an explicit and specific implementation in production
        /// to prevent the overhead of reflection.
        /// </summary>
        /// <typeparam name="T">The type of the target POCO objects.</typeparam>
        /// <param name="reader">The reader implementation.</param>
        /// <returns>The initialized object instance.</returns>
        public static async Task<T> To<T>(IReader reader)
            where T : new()
        {
            var properties = typeof(T).GetProperties();
            var value = new T();
            foreach (var property in properties)
            {
                var index = reader.IndexByName(property.Name);
                property.SetValue(value, await reader.Get(index, property.PropertyType));
            }

            return value;
        }
    }
}