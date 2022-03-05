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
    public class SliderController : BaseController
    {
        public SliderController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }


        // post
        [HttpPost]
        [Route("AddSlider", Name = "AddSlider")]
        public async Task<IActionResult> AddSlider(SliderDto slider)
        {
            var _slider = await _unitOfWork.Sliders
                .UpdateASliderFromSliderDto(slider, new Slider());
                
            var result = await _unitOfWork.Sliders.AddAsync(_slider);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetSlider", new { id = _slider.Id }, slider);
        }

        [HttpPost]
        [Route("AddRangeOfSliders", Name = "AddRangeOfSliders")]
        public async Task<IActionResult> AddRangeOfSliders(IEnumerable<SliderDto> sliders)
        {
            List<Slider> _sliders = new List<Slider>();
            foreach (var newSlider in sliders)
            {
                _sliders.Add(await _unitOfWork.Sliders
                    .UpdateASliderFromSliderDto(newSlider, new Slider()));
            }
            bool result = await _unitOfWork.Sliders.AddRangeAsync(_sliders);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return Ok(_sliders);
        }

        // get all with slider
        [HttpGet]
        [Route("GetAllWithPhotoURL", Name = "GetAllWithPhotoURL")]
        public async Task<IActionResult> GetSliderWithPhotoURL()
        {
            var sliders = await _unitOfWork.Sliders.GetAllWithPhotos();
            return Ok(sliders);
        }

        // get all
        [HttpGet]
        [Route("GetAllSliders", Name = "GetAllSliders")]
        public async Task<IActionResult> GetSliders()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync();
            return Ok(sliders);
        }

        // get
        [HttpGet]
        [Route("GetSlider", Name = "GetSlider")]

        public async Task<IActionResult> GetSlider(int id)
        {
            var slider = await _unitOfWork.Sliders.GetByIdAsync(id);
            return Ok(slider);
        }

        // delete
        [HttpDelete]
        [Route("DeleteSlider", Name = "DeleteSlider")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            bool result = await _unitOfWork.Sliders.DeleteAsync(id);
            if (!result)
                return BadRequest("Error while deleting");
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        // update
        [HttpPost]
        [Route("UpdateSlider", Name = "UpdateSlider")]
        public async Task<IActionResult> UpdateSlider(int id, SliderDto slider)
        {
            var sliderForUpdate = await _unitOfWork.Sliders.GetByIdAsync(id);
            if (sliderForUpdate == null)
                return BadRequest("Does not exist");
            
            sliderForUpdate = await _unitOfWork.Sliders
                .UpdateASliderFromSliderDto(slider, sliderForUpdate);

            bool result = await _unitOfWork.Sliders.UpdateAsync(sliderForUpdate);
            if (!result)
                return BadRequest("Error while updating");
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}
