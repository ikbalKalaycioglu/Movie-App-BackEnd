using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PosterManager : IPosterService
    {
        IPosterDal _posterDal;
        IFileHelper _fileHelper;

        public PosterManager(IPosterDal posterDal, IFileHelper fileHelper)
        {
            _posterDal = posterDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, Poster poster)
        {
            poster.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            _posterDal.Add(poster);
            return new SuccessResult(Messages.PosterAdded);
        }

        public IDataResult<List<Poster>> GetAll()
        {
            return new SuccessDataResult<List<Poster>>(_posterDal.GetAll());
        }

        public IDataResult<List<Poster>> GetByContentId(int contentId)
        {
            if (ChechPoster(contentId).Success)
            {
                return new SuccessDataResult<List<Poster>>(_posterDal.GetAll(c => c.ContentId == contentId));
            }
            return GetDefaultImage(contentId);
        }

        public IDataResult<Poster> GetByPosterId(int id)
        {
            return new SuccessDataResult<Poster>(_posterDal.Get(c => c.Id == id));
        }

        public IResult Delete(int id)
        {
            var result = _posterDal.Get(c => c.Id == id).ImagePath;
            
            _fileHelper.Delete(PathConstants.ImagePath + result);
            _posterDal.Delete(id);
            return new SuccessResult(Messages.PosterDeleted);
        }

        public IResult Update(IFormFile file, Poster poster)
        {
            poster.ImagePath = _fileHelper.Update(file, PathConstants.ImagePath + poster.ImagePath, PathConstants.ImagePath);
            _posterDal.Update(poster);
            return new SuccessResult();
        }


        private IResult ChechPoster(int contentId)
        {
            var result = _posterDal.GetAll(c => c.ContentId == contentId).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PosterAny);
        }

        private IDataResult<List<Poster>> GetDefaultImage(int contentId)
        {
            List<Poster> poster = new List<Poster>();
            poster.Add(new Poster
            {
                ContentId = contentId,
                ImagePath = "DefaultImage.jpg",
            });
            return new SuccessDataResult<List<Poster>>(poster);
        }
    }
}
