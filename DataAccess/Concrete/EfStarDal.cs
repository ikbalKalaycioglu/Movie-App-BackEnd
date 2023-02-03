using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using Entity.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfStarDal : EfEntityRepositoryBase<Star, BitirmeProjesiContext>, IStarDal
    {
        public List<StarDetailDto> GetStarDetails(Expression<Func<StarDetailDto, bool>> filter = null)
        {
            using (BitirmeProjesiContext context = new BitirmeProjesiContext())
            {
                var result = from star in context.Stars

                             select new StarDetailDto
                             {
                                 Id = star.StarId,
                                 Bio = star.Bio,
                                 BornDate = star.BornDate,
                                 FirstName = star.FirstName,
                                 LastName = star.LastName,
                                 ImagePath = (from m in context.starImages where m.StarId == star.StarId select m.ImagePath).FirstOrDefault(),
                                 ContentId = star.ContentId,
                             };


                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
