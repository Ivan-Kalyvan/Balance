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
    public class CertificateController : BaseController
    {
        public CertificateController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

    
        // add
        [HttpPost]
        [Route("AddCertificate", Name = "AddCertificate")]
        public async Task<IActionResult> AddCertificate(CertificateDto certificate)
        {
            Certificate _certificate = await _unitOfWork.Certificates
                .UpdateACertificateFromCertificateDto(certificate, new Certificate());

            bool result = await _unitOfWork.Certificates.AddAsync(_certificate);
            if (!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetCertificate", new { id = _certificate.Id }, certificate);
           
        }

        // addrange
        [HttpPost]
        [Route("AddRangeOfCertificates", Name = "AddRangeOfCertificates")]
        public async Task<IActionResult> AddRangeOfCertificates(IEnumerable<CertificateDto> certificates)
        {
         
            List<Certificate> _certificates = new List<Certificate>();
            foreach (var newCertificate in certificates)
            {
                _certificates.Add(await _unitOfWork.Certificates
                    .UpdateACertificateFromCertificateDto(newCertificate, new Certificate()));
            }
            bool result = await _unitOfWork.Certificates.AddRangeAsync(_certificates);
            if(!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();
            return Ok(_certificates);
            
        }

        // getById
        [HttpGet]
        [Route("GetCertificate", Name = "GetCertificate")]
        public async Task<IActionResult> GetCertificate(int Id)
        {
            var result = await _unitOfWork.Certificates.GetByIdAsync(Id);
            return Ok(result);
        }

        // get
        [HttpGet]
        [Route("GetAllCertificates", Name = "GetAllCertificates")]
        public async Task<IActionResult> GetCertificates()
        {
            var Achievements = await _unitOfWork.Certificates.GetAllAsync();
            return Ok(Achievements);
        }

        [HttpGet]
        [Route("GetCertificatesWithPhotoByType", Name = "GetCertificatesWithPhotoByType")]
        public async Task<IActionResult> GetCertificatesWithPhotoByType(string type)
        {
            var certifiactes = await _unitOfWork.Certificates.GetCertificatesWithPhotoByType(type);
            return Ok(certifiactes);
        }

        // delete
        [HttpDelete]
        [Route("DeleteCertificate", Name = "DeleteCertificate")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            
            bool result = await _unitOfWork.Certificates.DeleteAsync(id);
            if(!result)
                return BadRequest("Error while adding");
            await _unitOfWork.CompleteAsync();

            return Ok("Removal was successful");
        }

        // update
        [HttpPost]
        [Route("UpdateCertificate", Name = "UpdateCertificate")]
        public async Task<IActionResult> UpdateCertificate(CertificateDto certificate, int id)
        {
            
            Certificate certificateForUpdate = await _unitOfWork.Certificates.GetByIdAsync(id);
            if (certificateForUpdate == null)
                return BadRequest("Does not exist");

            certificateForUpdate = await _unitOfWork.Certificates
                .UpdateACertificateFromCertificateDto(certificate, certificateForUpdate);

            bool result = await _unitOfWork.Certificates.UpdateAsync(certificateForUpdate);
            if (!result)
                return BadRequest("Error while updating");
            await _unitOfWork.CompleteAsync();
            return Ok(); 
        }
    }
}
