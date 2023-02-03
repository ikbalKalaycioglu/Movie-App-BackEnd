using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStarImageService
    {
        IResult Add(IFormFile file, StarImage starImage);
        IResult Delete(int id);
        IResult Update(IFormFile file, StarImage starImage);
        IDataResult<List<StarImage>> GetAll();
        IDataResult<List<StarImage>> GetByStarId(int starId);
        IDataResult<StarImage> GetByStarImageId(int id);
    }
}
