using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        // get all entities
        Task<IEnumerable<T>> GetAllAsync();

        // get specific entitry based on id
        Task<T> GetByIdAsync(int id);

        Task<bool> AddAsync(T item);

        // update entity or add if it does not exist
        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(int id);

        Task<bool> AddRangeAsync(IEnumerable<T> items);
    }
}
