using Balance.DataService.IConfiguration;
using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Controllers
{
    public class WorkoutController : BaseController
    {
        public WorkoutController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        // add workout
        [HttpPost]
        [Route("AddWorkout", Name = "AddWorkout")]
        public async Task<IActionResult> AddWorkout(WorkoutDto workout)
        {
            var _workout = await _unitOfWork.Workouts
                .UpdateAWorkoutfromWorkoutDto(workout, new Workout()); ;

            bool result = await _unitOfWork.Workouts.AddAsync(_workout);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetWorkoutById", new { id = _workout.Id }, workout);
        }

        [HttpPost]
        [Route("AddRangeOfWorkouts", Name = "AddRangeOfWorkouts")]
        public async Task<IActionResult> AddRangeOfWorkouts(IEnumerable<WorkoutDto> workouts)
        {
            List<Workout> _workouts = new List<Workout>();
            foreach (var newWorkout in workouts)
            {
                _workouts.Add(await _unitOfWork.Workouts
                .UpdateAWorkoutfromWorkoutDto(newWorkout, new Workout()));
            }
            bool result = await _unitOfWork.Workouts.AddRangeAsync(_workouts);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return Ok(_workouts);
        }

        // get
        [HttpGet]
        [Route("GetWorkoutById", Name = "GetWorkoutById")]
        public async Task<IActionResult> GetWorkoutById(int id)
        {
            var _workout = await _unitOfWork.Workouts.GetByIdAsync(id);
            if (_workout == null)
                return BadRequest("Does not exist");
            return Ok(_workout);
        }

        // get all
        [HttpGet]
        [Route("GetAllWorkouts", Name = "GetAllWorkouts")]
        public async Task<IActionResult> GetAllWorkouts()
        {
            var _workouts = await _unitOfWork.Workouts.GetAllAsync();
            return Ok(_workouts);
        }

        // get all with InfoCards and photoURL
        [HttpGet("GetAllWithInfoCardsAndPhotoURLByType")]
        public async Task<IActionResult> GetAllWorkoutsWithInfocardsAndPhotos(string type)
        {
            var workouts = await _unitOfWork.Workouts
                .GetAllWithInfoCardsAndPhotoURLByType(type);
            return Ok(workouts);
        }

        [HttpGet("GetAllWithPhotos")]
        public async Task<IActionResult> GetAllWithPhotos()
        {
            var workouts = await _unitOfWork.Workouts.GetAllWithPhotos();
            return Ok(workouts);
        }

        // delete
        [HttpDelete]
        [Route("DeleteWorkout", Name = "Delete Workout")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            bool result = await _unitOfWork.Workouts.DeleteAsync(id);
            if (!result)
                return BadRequest("Error while deleting");
            await _unitOfWork.CompleteAsync();

            return Ok("Removal was successful");
        }

        // update
        [HttpPost]
        [Route("UpdateWorkout", Name = "UpdateWorkout")]
        public async Task<IActionResult> UpdateWorkout(WorkoutDto workout, int id)
        {
            var _workoutForUpdate = await _unitOfWork.Workouts.GetByIdAsync(id);
            if (_workoutForUpdate == null)
                return BadRequest("Deos not exist");

            _workoutForUpdate = await _unitOfWork.Workouts
                .UpdateAWorkoutfromWorkoutDto(workout, _workoutForUpdate);

            bool result = await _unitOfWork.Workouts.UpdateAsync(_workoutForUpdate);
            if (!result)
                return BadRequest("Erorr while updating");
            await _unitOfWork.CompleteAsync();
            return Ok(_workoutForUpdate);
        }
    }
}
