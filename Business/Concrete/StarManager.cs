using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class StarManager : IStarService
    {
        IStarDal _starDal;

        public StarManager(IStarDal starDal)
        {
            _starDal = starDal;
        }

        public IDataResult<int> Add(Star star)
        {
            _starDal.Add(star);
            var result = _starDal.Get(c => c.StarId == star.StarId);
            if (result != null)
            {
                return new SuccessDataResult<int>(result.StarId, Messages.StarAdded);
            }
            return new ErrorDataResult<int>(-1);
        }

        public IResult Delete(int id)
        {
            _starDal.Delete(id);
            return new SuccessResult(Messages.StarDeleted);
        }

        public IDataResult<List<Star>> GetAll()
        {
            return new SuccessDataResult<List<Star>>(_starDal.GetAll());
        }

        public IDataResult<List<Star>> GetByContentId(int contentId)
        {
            return new SuccessDataResult<List<Star>>(_starDal.GetAll(x => x.ContentId == contentId));
        }

        public IDataResult<Star> GetById(int id)
        {
            return new SuccessDataResult<Star>(_starDal.Get(c => c.StarId == id));
        }

        public IDataResult<StarDetailDto> GetDetailsById(int starId)
        {
            return new SuccessDataResult<StarDetailDto>(_starDal.GetStarDetails(x=>x.Id== starId).FirstOrDefault());
        }

        public IDataResult<List<StarDetailDto>> GetStarDetails()
        {
            return new SuccessDataResult<List<StarDetailDto>>(_starDal.GetStarDetails());
        }

        public IDataResult<List<StarDetailDto>> GetStarDetailsByContentId(int contentId)
        {
            return new SuccessDataResult<List<StarDetailDto>>(_starDal.GetStarDetails(x => x.ContentId == contentId));
        }

        public IResult Update(Star star)
        {
            _starDal.Update(star);
            return new SuccessResult(Messages.StarUpdated);
        }
    }
}
