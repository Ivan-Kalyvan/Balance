using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface IWorkoutRepository : IGenericRepository<Workout>
    {
        Task<IEnumerable<Workout>> GetAllWithInfoCardsAndPhotoURLByType(string type);
        Task<IEnumerable<Workout>> GetAllWithPhotos();
        Task<Workout> UpdateAWorkoutfromWorkoutDto(
            WorkoutDto workoutDto,
            Workout workoutForUpdate);
    }
}
