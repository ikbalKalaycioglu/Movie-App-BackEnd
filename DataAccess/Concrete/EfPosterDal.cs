using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfPosterDal : EfEntityRepositoryBase<Poster, BitirmeProjesiContext>, IPosterDal
    {
    }
}
