using Balance.Entities.DbSet;
using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.IRepository
{
    public interface ISliderRepository : IGenericRepository<Slider>
    {
        Task<IEnumerable<Slider>> GetAllWithPhotos();

        Task<Slider> UpdateASliderFromSliderDto(SliderDto sliderDto, Slider sliderForUpdate);
    }
}
