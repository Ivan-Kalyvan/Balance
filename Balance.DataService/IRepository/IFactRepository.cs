using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface IFactRepository : IGenericRepository<Fact>
    {
        Task<IEnumerable<Fact>> GetFactsById(IEnumerable<int> factsIds);
        Task<Fact> UpdatingAFactFromFactDto(FactDto factDto, Fact factForUpdate);
    }
}
