using Balance.DataService.IConfiguration;
using Balance.DataService.IRepository;
using Balance.DataService.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public ISliderRepository Sliders { get; private set; }
        public ICertificateRepository Certificates { get; private set; }
        public IInfoCardRepository InfoCards { get; private set; }
        public IWorkoutRepository Workouts { get; private set; }
        public IPhotoURLRepository PhotosURL { get; private set; }
        public IFactRepository Facts { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Sliders = new SliderRepository(context);
            Certificates = new CertificateRepository(context);
            InfoCards = new InfoCardRepository(context);
            Workouts = new WorkoutRepository(context);
            PhotosURL = new PhotoURLRepository(context);
            Facts = new FactsRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
