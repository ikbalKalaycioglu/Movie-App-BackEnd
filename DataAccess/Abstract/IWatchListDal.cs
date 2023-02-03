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
    public interface IWatchListDal : IEntityRepository<WatchList>
    {
        List<WatchListDto> GetContenByUser(Expression<Func<WatchListDto, bool>> filter = null);

    }
}
