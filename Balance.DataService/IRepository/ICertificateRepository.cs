using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface ICertificateRepository : IGenericRepository<Certificate>
    {
        Task<IEnumerable<Certificate>> GetCertificatesById(IEnumerable<int> ids);
        Task<IEnumerable<Certificate>> GetCertificatesWithPhotoByType(string type);
        Task<Certificate> UpdateACertificateFromCertificateDto(
            CertificateDto certificateDto,
            Certificate certificateForUpdate);
    }
}
