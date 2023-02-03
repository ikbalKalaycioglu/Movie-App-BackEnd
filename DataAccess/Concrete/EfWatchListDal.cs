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
    public class EfWatchListDal : EfEntityRepositoryBase<WatchList, BitirmeProjesiContext>, IWatchListDal
    {
        public List<WatchListDto> GetContenByUser(Expression<Func<WatchListDto, bool>> filter = null)
        {
            using (var context = new BitirmeProjesiContext())
            {
                var result = from watchList in context.WatchList
                             join user in context.Users
                             on watchList.UserId equals user.Id
                             join content in context.Contents
                             on watchList.ContentId equals content.Id

                             select new WatchListDto
                             {
                                 Id = watchList.Id,
                                 contentId = content.Id,
                                 Description = content.Description,
                                 Genre = content.Genre,
                                 IMDbRating = content.IMDbRating,
                                 Title = content.Title,
                                 userId = user.Id,
                                 PosterPath = (from m in context.Posters where m.ContentId == content.Id select m.ImagePath).FirstOrDefault(),
                                 watched = watchList.watched,
                             };

                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
