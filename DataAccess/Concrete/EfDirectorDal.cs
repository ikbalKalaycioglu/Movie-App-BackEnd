using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using Entity.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfDirectorDal : EfEntityRepositoryBase<Director, BitirmeProjesiContext>, IDirectorDal
    {
        public List<DirectorDetailDto> GetDirectorDetails(Expression<Func<DirectorDetailDto, bool>> filter = null)
        {
            using (BitirmeProjesiContext context = new BitirmeProjesiContext())
            {
                var result = from director in context.Directors

                             select new DirectorDetailDto
                             {
                                 Id = director.DirectorId,
                                 Bio = director.Bio,
                                 BornDate= director.BornDate,
                                 FirstName= director.FirstName,
                                 LastName= director.LastName,
                                 ImagePath = (from m in context.DirectorImages where m.DirectorId == director.DirectorId select m.ImagePath).FirstOrDefault(),
                                 ContentId = director.ContentId,
                             };

                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
