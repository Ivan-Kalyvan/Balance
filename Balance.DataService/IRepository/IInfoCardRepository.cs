using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface IInfoCardRepository : IGenericRepository<InfoCard>
    {
        Task<IEnumerable<InfoCard>> GetAllWithFacts();
        Task<InfoCard> GetWithFactsById(int id);
        Task<IEnumerable<InfoCard>> GetInfoCardsByIds(List<int> ids);
        Task<IEnumerable<InfoCard>> GetInfoCardWithPhotoAndFactsByType(string type);

        Task<InfoCard> UpdatingAInfoCardFromInfoCardDto(
            InfoCardDto infoCardDto,
            InfoCard infoCardForUpdate);
    }
}
