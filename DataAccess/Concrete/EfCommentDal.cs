using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, BitirmeProjesiContext>, ICommentDal
    {
        public List<CommentDetailDto> GetCommentDetails(Expression<Func<CommentDetailDto, bool>> filter = null)
        {
            using (BitirmeProjesiContext context = new BitirmeProjesiContext())
            {
                var result = from comment in context.Comments
                             join user in context.Users
                             on comment.userId equals user.Id

                             select new CommentDetailDto
                             {
                                 Id = comment.Id,
                                 contentId = comment.contentId,
                                 userId = comment.userId,
                                 Display = comment.Display,
                                 Message = comment.Message,
                                 userName = user.FirstName + " " + user.LastName,
                                 Email = user.Email
                             };


                return filter is null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
