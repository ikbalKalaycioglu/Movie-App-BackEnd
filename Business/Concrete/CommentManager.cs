using Business.Abstract;
using Business.Constants;
using Core.Entites;
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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(int id)
        {
            _commentDal.Delete(id);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<CommentDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<CommentDetailDto>>(_commentDal.GetCommentDetails());
        }

        public IDataResult<List<CommentDetailDto>> GetByContentId(int contentId)
        {
            var result = _commentDal.GetCommentDetails(x => x.contentId == contentId);
            return new SuccessDataResult<List<CommentDetailDto>>(result);
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult("Comment Güncellendi");
        }
    }
}
