using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IDirectorService
    {
        IDataResult<List<Director>> GetAll();
        IDataResult<Director> GetById(int id);
        IDataResult<List<Director>> GetByContentId(int contentId);
        IDataResult<List<DirectorDetailDto>> GetDirectorDetails();
        IDataResult<List<DirectorDetailDto>> GetDirectorDetailsByContentId(int contentId);
        IDataResult<DirectorDetailDto> GetDirectorDetailsById(int directorId);
        IDataResult<int> Add(Director director);
        IResult Delete(int id);
        IResult Update(Director director);
    }
}
