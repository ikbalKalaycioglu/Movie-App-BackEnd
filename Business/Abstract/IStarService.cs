using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IStarService
    {
        IDataResult<List<Star>> GetAll();
        IDataResult<Star> GetById(int id);
        IDataResult <List<Star>> GetByContentId(int contentId);
        IDataResult<int> Add(Star star);
        IResult Delete(int id);
        IResult Update(Star star);
        IDataResult<List<StarDetailDto>> GetStarDetails();
        IDataResult<List<StarDetailDto>> GetStarDetailsByContentId(int contentId);
        IDataResult<StarDetailDto> GetDetailsById(int starId);
    }
}
