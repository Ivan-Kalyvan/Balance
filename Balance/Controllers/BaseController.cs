using Balance.DataService.IConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
