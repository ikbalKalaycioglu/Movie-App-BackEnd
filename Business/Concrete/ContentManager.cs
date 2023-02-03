using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        [SecuredOperation("admin,editor")]
        public IDataResult<int> Add(Content content)
        {
            _contentDal.Add(content);
            var result = _contentDal.Get(c => c.Id == content.Id);
            if (result != null)
            {
                return new SuccessDataResult<int>(result.Id,Messages.ContentAdded);
            }
            return new ErrorDataResult<int>(-1);
        }

        public IResult Delete(int id)
        {
            _contentDal.Delete(id);
            return new SuccessResult(Messages.ContentDeleted);
        }
        public IDataResult<List<Content>> GetAll()
        {
            return new SuccessDataResult<List<Content>>(_contentDal.GetAll()); 
        }

        public IDataResult<Content> GetById(int id)
        {
            return new SuccessDataResult<Content>(_contentDal.Get(x => x.Id== id));
        }

        public IDataResult<List<ContentDetailDto>> GetContentByCategoryId(int Categoryid)
        {
            return new SuccessDataResult<List<ContentDetailDto>>(_contentDal.GetContentDetails(x => x.CategoryId == Categoryid));
        }

        public IDataResult<ContentDetailDto> GetContentById(int id)
        {
            return new SuccessDataResult<ContentDetailDto>((_contentDal.GetContentDetails(x=> x.Id == id)).FirstOrDefault());
        }

        public IDataResult<List<ContentDetailDto>> GetContentDetails()
        {
            return new SuccessDataResult<List<ContentDetailDto>>(_contentDal.GetContentDetails());

        }
        public IResult Update(Content content)
        {
            _contentDal.Update(content);
            return new SuccessResult(Messages.ContentUpdated);
        }
    }
}
