using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStarDal :IEntityRepository<Star>
    {
        List<StarDetailDto> GetStarDetails(Expression<Func<StarDetailDto, bool>> filter = null);
    }
}
