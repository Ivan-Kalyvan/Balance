using Balance.DataService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IConfiguration
{
    public interface IUnitOfWork
    {
        ISliderRepository Sliders { get; }
        ICertificateRepository Certificates { get; }
        IInfoCardRepository InfoCards { get; }
        IWorkoutRepository Workouts { get; }
        IPhotoURLRepository PhotosURL { get; }
        IFactRepository Facts { get; }

        Task CompleteAsync();
    }
}
