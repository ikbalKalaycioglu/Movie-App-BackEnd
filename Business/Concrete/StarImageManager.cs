using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StarImageManager : IStarImageService
    {
        IStarImageDal _starImageDal;
        IFileHelper _fileHelper;

        public StarImageManager(IStarImageDal starImageDal, IFileHelper fileHelper)
        {
            _starImageDal = starImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, StarImage starImage)
        {
            starImage.ImagePath = _fileHelper.Upload(file, PathConstants.StarImagePath);
            _starImageDal.Add(starImage);
            return new SuccessResult(Messages.PosterAdded);
        }

        public IResult Delete(int id)
        {
            var result = _starImageDal.Get(c => c.Id == id).ImagePath;

            _fileHelper.Delete(PathConstants.StarImagePath + result);
            _starImageDal.Delete(id);
            return new SuccessResult(Messages.StarImageDeleted);
        }

        public IDataResult<List<StarImage>> GetAll()
        {
            return new SuccessDataResult<List<StarImage>>(_starImageDal.GetAll());
        }

        public IDataResult<List<StarImage>> GetByStarId(int starId)
        {
            if (ChechPoster(starId).Success)
            {
                return new SuccessDataResult<List<StarImage>>(_starImageDal.GetAll(c => c.StarId == starId));
            }
            return GetDefaultImage(starId);
        }

        public IDataResult<StarImage> GetByStarImageId(int id)
        {
            return new SuccessDataResult<StarImage>(_starImageDal.Get(c => c.Id == id));
        }

        public IResult Update(IFormFile file, StarImage starImage)
        {
            starImage.ImagePath = _fileHelper.Update(file, PathConstants.StarImagePath + starImage.ImagePath, PathConstants.StarImagePath);
            _starImageDal.Update(starImage);
            return new SuccessResult();
        }


        private IResult ChechPoster(int starId)
        {
            var result = _starImageDal.GetAll(c => c.StarId == starId).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PosterAny);
        }

        private IDataResult<List<StarImage>> GetDefaultImage(int starId)
        {
            List<StarImage> starImage = new List<StarImage>();
            starImage.Add(new StarImage
            {
                StarId = starId,
                ImagePath = "DefaultImage.jpg",
            });
            return new SuccessDataResult<List<StarImage>>(starImage);
        }
    }
}
