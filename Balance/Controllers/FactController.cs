using Balance.DataService.IConfiguration;
using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Controllers
{
    public class FactController : BaseController
    {
        public FactController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        // add fact
        [HttpPost]
        [Route("AddFact", Name = "AddFact")]
        public async Task<IActionResult> AddFact(FactDto fact)
        {
            
            Fact _fact = await _unitOfWork.Facts
                .UpdatingAFactFromFactDto(fact, new Fact());

            bool result = await _unitOfWork.Facts.AddAsync(_fact);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetFactById", new { Id = _fact.Id }, fact);
            
        }

        [HttpPost]
        [Route("AddRangeOfFacts", Name = "AddRangeOfFacts")]
        public async Task<IActionResult> AddRangeOfFacts(IEnumerable<FactDto> facts)
        {
            List<Fact> _facts = new List<Fact>();
            foreach (var newFact in facts)
            {
                _facts.Add(await _unitOfWork.Facts
                    .UpdatingAFactFromFactDto(newFact, new Fact()));
            }
            bool result = await _unitOfWork.Facts.AddRangeAsync(_facts);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();
            return Ok(_facts);
           
        }

        // get all facts
        [HttpGet]
        [Route("GetAllFacts", Name = "GetAllFacts")]
        public async Task<IActionResult> GetFacts()
        {
            var facts = await _unitOfWork.Facts.GetAllAsync();
            return Ok(facts);
        }

        // get by id
        [HttpGet]
        [Route("GetFactById", Name = "GetFactById")]
        public async Task<IActionResult> GetById(int id)
        {
            Fact _fact = await _unitOfWork.Facts.GetByIdAsync(id);
            if (_fact == null)
                return BadRequest("Does not exist");
            return Ok(_fact);            
        }

        // delete
        [HttpDelete]
        [Route("DeleteFact", Name = "DeleteFact")]
        public async Task<IActionResult> DeleteFact(int id)
        {
            bool result = await _unitOfWork.Facts.DeleteAsync(id);
            if(!result)
                return BadRequest("Error while deleting");

            await _unitOfWork.CompleteAsync();

            return Ok("Removal was successful");
        }

        // update
        [HttpPost]
        [Route("UpdateFact", Name = "UpdateFact")]
        public async Task<IActionResult> UpdateFact(FactDto fact, int id)
        {
            var _factForUpdate = await _unitOfWork.Facts.GetByIdAsync(id);
            if (_factForUpdate == null)
                return BadRequest("Does not exist");

            _factForUpdate = await _unitOfWork.Facts
                .UpdatingAFactFromFactDto(fact, _factForUpdate);

            bool result = await _unitOfWork.Facts.UpdateAsync(_factForUpdate);
            if(!result)
                return BadRequest("Error while updating");
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}
