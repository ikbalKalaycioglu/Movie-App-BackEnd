using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DirectorManager : IDirectorService
    {
        IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public IDataResult<int> Add(Director director)
        {
            _directorDal.Add(director);
            var result = _directorDal.Get(c => c.DirectorId == director.DirectorId);
            if (result != null)
            {
                return new SuccessDataResult<int>(result.DirectorId, Messages.DirectorAdded);
            }
            return new ErrorDataResult<int>(-1);
        }

        public IResult Delete(int id)
        {
            _directorDal.Delete(id);
            return new SuccessResult(Messages.DirectorDeleted);
        }

        public IDataResult<List<Director>> GetAll()
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll());
        }

        public IDataResult<List<Director>> GetByContentId(int contentId)
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(x=>x.ContentId == contentId));
        }

        public IDataResult<Director> GetById(int id)
        {
            return new SuccessDataResult<Director>(_directorDal.Get(c => c.DirectorId == id));
        }

        public IDataResult<List<DirectorDetailDto>> GetDirectorDetails()
        {
            return new SuccessDataResult<List<DirectorDetailDto>>(_directorDal.GetDirectorDetails());
        }

        public IDataResult<List<DirectorDetailDto>> GetDirectorDetailsByContentId(int contentId)
        {
            return new SuccessDataResult<List<DirectorDetailDto>>(_directorDal.GetDirectorDetails(x => x.ContentId == contentId));
        }

        public IDataResult<DirectorDetailDto> GetDirectorDetailsById(int directorId)
        {
            return new SuccessDataResult<DirectorDetailDto>(_directorDal.GetDirectorDetails(x => x.Id == directorId).FirstOrDefault());
        }


        public IResult Update(Director director)
        {
            _directorDal.Update(director);
            return new SuccessResult(Messages.DirectorUpdated);
        }
    }
}
