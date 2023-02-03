using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WatchListManager : IWatchListService
    {
        IWatchListDal _watchListDal;
        public WatchListManager(IWatchListDal watchListDal)
        {
            _watchListDal = watchListDal;
        }

        public IResult Add(WatchList watchList)
        {
            var result = _watchListDal.GetAll(x => x.ContentId == watchList.ContentId && x.UserId == watchList.UserId).Any();
            if (result)
            {
                return new ErrorResult(Messages.watchListAlreadyExist);
            }
            else
            {
                _watchListDal.Add(watchList);
                return new SuccessResult(Messages.watchListAdded);
            }
            
        }

        public IResult ChangeWatched(WatchList watchList)
        {
            var result = _watchListDal.Get(x => x.ContentId == watchList.ContentId && x.UserId == watchList.UserId);
            if (result != null)
            {
                result.watched = !result.watched ;
                _watchListDal.Update(result);
                return new SuccessResult(Messages.watchListUpdated);
            }
            return new ErrorResult(result.watched.ToString());
           
        }

        public IResult Delete(int id)
        {
            _watchListDal.Delete(id);
            return new SuccessResult(Messages.watchListDeleted);
        }

        public IDataResult<List<WatchListDto>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<WatchListDto>>(_watchListDal.GetContenByUser(x => x.userId == id));
        }
    }
}
