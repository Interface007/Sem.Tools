using System.Threading.Tasks;

namespace Sem.Data.SprocAccess
{
    public interface IReader
    {
        Task<bool> Read();

        Task<T> Get<T>(int index);

        Task NextResult();

        Task Close();
    }
}
