using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(Comment comment);
        IResult Delete(int id);
        IResult Update(Comment comment);
        IDataResult<List<CommentDetailDto>> GetAll();
        IDataResult<List<CommentDetailDto>> GetByContentId(int contentId);
    }
}
