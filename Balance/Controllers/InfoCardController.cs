using Balance.DataService.Data;
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
    public class InfoCardController : BaseController
    {
        public InfoCardController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        // add
        [HttpPost]
        [Route("AddInfoCard", Name = "AddInfoCard")]
        public async Task<IActionResult> AddInfoCard(InfoCardDto infoCard)
        {
            
            InfoCard _newInfoCard = await _unitOfWork.InfoCards
                .UpdatingAInfoCardFromInfoCardDto(infoCard, new InfoCard());

            bool result = await _unitOfWork.InfoCards.AddAsync(_newInfoCard);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetInfoCard", new { id = _newInfoCard.Id }, infoCard);
           
        }

        [HttpGet]
        [Route("AddRangeOfInfoCards", Name = "AddRangeOfInfoCards")]
        public async Task<IActionResult> AddRangeOfInfoCards(IEnumerable<InfoCardDto> infoCards)
        {
            List<InfoCard> _infoCards = new List<InfoCard>();
            foreach (var newInfoCard in infoCards)
            {
                _infoCards.Add(await _unitOfWork.InfoCards
                    .UpdatingAInfoCardFromInfoCardDto(newInfoCard, new InfoCard()));
            }
            bool result = await _unitOfWork.InfoCards.AddRangeAsync(_infoCards);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();
            return Ok(_infoCards);   
        }

        // getall
        [HttpGet]
        [Route("GetAllInfoCards", Name = "GetAllInfoCards")]
        public async Task<IActionResult> GetInfoCards()
        {
            var _infoCards = await _unitOfWork.InfoCards.GetAllAsync();
            return Ok(_infoCards);
        }

        [HttpGet]
        [Route("GetAllWithPhotoAndFactsByType", Name = "GetAllWithPhotoAndFactsByType")]
        public async Task<IActionResult> GetAllWithPhotoAndFactsByType(string type)
        {
            var _infoCards = await _unitOfWork.InfoCards.GetInfoCardWithPhotoAndFactsByType(type);
            return Ok(_infoCards);
        }

        // getById
        [HttpGet]
        [Route("GetInfoCard", Name = "GetInfoCard")]
        public async Task<IActionResult> GetInfoCardById(int id)
        {
            var _infoCard = await _unitOfWork.InfoCards.GetByIdAsync(id);
            if (_infoCard == null)
                return BadRequest("Does not exist");
            return Ok(_infoCard);
        }

        [HttpGet]
        [Route("GetInfoCardsWithFacts", Name = "GetInfoCardsWithFacts")]
        public async Task<IActionResult> GetInfoCardsWithFacts()
        {
            var _infoCards = await _unitOfWork.InfoCards.GetAllWithFacts();
            if(_infoCards != null)
                return Ok(_infoCards);
            else
                return Ok(new List<InfoCard>());
        }

        [HttpGet]
        [Route("GetInfoCardWithFacts", Name = "GetInfoCardWithFacts")]
        public async Task<IActionResult> GetInfoCardWithFacts(int id)
        {
            var _infoCard = await _unitOfWork.InfoCards.GetWithFactsById(id);
            if (_infoCard != null)
                return Ok(_infoCard);
            else
                return BadRequest();
        }

        // delete
        [HttpDelete]
        [Route("RemoveInfoCard", Name = "RemoveInfoCard")]
        public async Task<IActionResult> DeleteInfoCard(int id)
        {
            
            bool result = await _unitOfWork.InfoCards.DeleteAsync(id);
            if (!result)
                return BadRequest("Error during deletion");
            await _unitOfWork.CompleteAsync();

            return Ok("Removal was successful");
        }

        // todo изенить создание сущноснти для обновления
        // update
        [HttpPost]
        [Route("UpdateInfoCard", Name = "UpdateInfoCard")]
        public async Task<IActionResult> UpdateInfoCard(InfoCardDto infoCard, int id)
        {
            InfoCard _infoCardForUpdate = await _unitOfWork.InfoCards.GetByIdAsync(id);
            if (_infoCardForUpdate == null)
                return BadRequest("Does not exist");
                
            _infoCardForUpdate = await _unitOfWork.InfoCards
                .UpdatingAInfoCardFromInfoCardDto(infoCard, _infoCardForUpdate);

            bool result = await _unitOfWork.InfoCards.UpdateAsync(_infoCardForUpdate);
            if (!result)
                return BadRequest("Error while updating");
            await _unitOfWork.CompleteAsync();
            return Ok(_infoCardForUpdate);
        }
    }
}
