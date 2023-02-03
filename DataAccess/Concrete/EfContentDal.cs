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
    public class EfContentDal : EfEntityRepositoryBase<Content, BitirmeProjesiContext>, IContentDal
    {
        public List<ContentDetailDto> GetContentDetails(Expression<Func<ContentDetailDto, bool>> filter = null)
        {
            using (BitirmeProjesiContext context = new BitirmeProjesiContext())
            {
                var result = from content in context.Contents
                             join category in context.Categories
                             on content.CategoryId equals category.Id

                             select new ContentDetailDto
                             {
                                 Id = content.Id,
                                 CategoryName = category.Name,
                                 CategoryId = category.Id,
                                 Description = content.Description,
                                 Genre = content.Genre,
                                 IMDbRating = content.IMDbRating,
                                 PlaybackURL = content.PlaybackURL,
                                 PosterPath = (from m in context.Posters where m.ContentId == content.Id select m.ImagePath).FirstOrDefault(),
                                 Title = content.Title,
                                 Writer = content.Writer,
                                 DirectorName = (from d in context.Directors where d.ContentId == content.Id select d.FirstName + " " + d.LastName).FirstOrDefault(),
                                 StarName = (from s in context.Stars where s.ContentId == content.Id select s.FirstName + " " + s.LastName).FirstOrDefault(),
                             };


                return filter is null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
