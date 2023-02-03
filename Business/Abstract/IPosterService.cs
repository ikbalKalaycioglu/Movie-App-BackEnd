using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IPosterService
    {
        IResult Add(IFormFile file, Poster poster);
        IResult Delete(int id);
        IResult Update(IFormFile file, Poster poster);
        IDataResult<List<Poster>> GetAll();
        IDataResult<List<Poster>> GetByContentId(int contentId);
        IDataResult<Poster> GetByPosterId(int id);
    }
}
