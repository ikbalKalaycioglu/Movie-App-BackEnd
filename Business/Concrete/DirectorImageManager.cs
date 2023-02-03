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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DirectorImageManager : IDirectorImageService
    {
        IFileHelper _fileHelper;
        IDirectorImageDal _directorImageDal;

        public DirectorImageManager(IFileHelper fileHelper, IDirectorImageDal directorImageDal)
        {
            _fileHelper = fileHelper;
            _directorImageDal = directorImageDal;
        }

        public IResult Add(IFormFile file, DirectorImage directorImage)
        {
            directorImage.ImagePath = _fileHelper.Upload(file, PathConstants.DirectorImagePath);
            _directorImageDal.Add(directorImage);
            return new SuccessResult(Messages.DirectorImageAdded);
        }

        public IResult Delete(int id)
        {
            var result = _directorImageDal.Get(c => c.Id == id).ImagePath;

            _fileHelper.Delete(PathConstants.DirectorImagePath + result);
            _directorImageDal.Delete(id);
            return new SuccessResult(Messages.DirectorImageDeleted);
        }

        public IDataResult<List<DirectorImage>> GetAll()
        {
            return new SuccessDataResult<List<DirectorImage>>(_directorImageDal.GetAll());
        }

        public IDataResult<List<DirectorImage>> GetByDirectorId(int directorId)
        {
            if (ChechDirectorImage(directorId).Success)
            {
                return new SuccessDataResult<List<DirectorImage>>(_directorImageDal.GetAll(x => x.DirectorId == directorId));

            }
            return GetDefaultImage(directorId);
        }

        public IDataResult<DirectorImage> GetById(int id)
        {
            return new SuccessDataResult<DirectorImage>(_directorImageDal.Get(x => x.Id == id));
        }

        public IResult Update(IFormFile file, DirectorImage directorImage)
        {
            directorImage.ImagePath = _fileHelper.Update(file, PathConstants.DirectorImagePath + directorImage.ImagePath, PathConstants.DirectorImagePath);
            _directorImageDal.Update(directorImage);
            return new SuccessResult(Messages.DirectorImageUpdated);
        }


        private IResult ChechDirectorImage(int directorId)
        {
            var result = _directorImageDal.GetAll(c => c.DirectorId == directorId).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.DirectorImageAny);
        }

        private IDataResult<List<DirectorImage>> GetDefaultImage(int directorId)
        {
            List<DirectorImage> directorImage = new List<DirectorImage>();
            directorImage.Add(new DirectorImage
            {
                ImagePath = "DefaultImage.jpg",
                DirectorId= directorId
            });
            return new SuccessDataResult<List<DirectorImage>>(directorImage);
        }
    }
}
