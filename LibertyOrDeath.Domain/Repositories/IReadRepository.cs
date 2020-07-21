using System.Collections.Generic;

namespace LibertyOrDeath.Domain.Repositories
{
    public interface IReadRepository<out T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
