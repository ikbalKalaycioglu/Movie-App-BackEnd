using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfStarImageDal : EfEntityRepositoryBase<StarImage,BitirmeProjesiContext>,IStarImageDal
    {
    }
}
