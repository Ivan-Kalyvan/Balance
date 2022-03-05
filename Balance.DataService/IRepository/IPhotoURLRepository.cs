using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface IPhotoURLRepository : IGenericRepository<PhotoURL>
    {
        Task<IEnumerable<PhotoURL>> GetPhotosById(IEnumerable<int> photosId);

        Task<PhotoURL> UpdatingAPhotoURLFromPhotoURLDto(PhotoURLDto photo, PhotoURL photoForUpdate);
    }
}
