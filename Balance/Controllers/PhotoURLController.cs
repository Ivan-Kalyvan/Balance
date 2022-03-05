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
    public class PhotoURLController : BaseController
    {
        public PhotoURLController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        // add
        [HttpPost]
        [Route("AddPhotoURL", Name = "AddPhotoURL")]
        public async Task<IActionResult> AddPhotoURL(PhotoURLDto photo)
        {
            PhotoURL _photoURL = await _unitOfWork.PhotosURL
                .UpdatingAPhotoURLFromPhotoURLDto(photo, new PhotoURL());
            bool result = await _unitOfWork.PhotosURL.AddAsync(_photoURL);
            if (!result)
                return BadRequest("Error While adding");
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetURLPhotoById", new { id = _photoURL.Id }, photo);   
        }

        [HttpPost]
        [Route("AddRangeOfPhotoURLs", Name = "AddRangeOfPhotoURLs")]
        public async Task<IActionResult> AddRangeOfPhotoURLs(IEnumerable<PhotoURLDto> photoURLs)
        {
            List<PhotoURL> _photoURLs = new List<PhotoURL>();
            foreach (var photoURL in photoURLs)
            {
                _photoURLs.Add(await _unitOfWork.PhotosURL
                    .UpdatingAPhotoURLFromPhotoURLDto(photoURL, new PhotoURL()));
            }
            bool result = await _unitOfWork.PhotosURL.AddRangeAsync(_photoURLs);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return Ok(_photoURLs);
        }

        // getAll
        [HttpGet]
        [Route("GetAllPhotos", Name = "GetAllPhotos")]
        public async Task<IActionResult> GetPhotoURL()
        {
            var photos = await _unitOfWork.PhotosURL.GetAllAsync();
            return Ok(photos);
        }

        // getById
        [HttpGet]
        [Route("GetURLPhotoById", Name = "GetURLPhotoById")]
        public async Task<IActionResult> GetPhotoURLById(int id)
        {
            var photo = await _unitOfWork.PhotosURL.GetByIdAsync(id);
            return Ok(photo);
        }

        // delete
        [HttpDelete]
        [Route("DeletePhoto", Name = "DeletePhoto")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            bool result = await _unitOfWork.PhotosURL.DeleteAsync(id);
            if (!result)
                return BadRequest("Error whule deleting");
            await _unitOfWork.CompleteAsync();

            return Ok("Removal was successful");
        }

        // update
        [HttpPost]
        [Route("UpdatePhoto", Name = "UpdatePhoto")]
        public async Task<IActionResult> UpdatePhoto(PhotoURLDto photo, int id)
        {
            var _photoForUpdate = await _unitOfWork.PhotosURL.GetByIdAsync(id);
            if (_photoForUpdate == null)
                return BadRequest("Does not exist");

            _photoForUpdate = await _unitOfWork.PhotosURL
                .UpdatingAPhotoURLFromPhotoURLDto(photo, _photoForUpdate);

            bool result = await _unitOfWork.PhotosURL.UpdateAsync(_photoForUpdate);
            if(!result)
                return BadRequest("Error while updating");
            await _unitOfWork.CompleteAsync();
            return Ok(_photoForUpdate);
        }
    }
}
