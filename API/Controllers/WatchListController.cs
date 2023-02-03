using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        IWatchListService _watchListService;

        public WatchListController(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        [HttpGet("getByUserId")]
        public IActionResult GetById(int id)
        {
            var result = _watchListService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(WatchList watchList)
        {
            var result = _watchListService.Add(watchList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("ChangeWatched")]
        public IActionResult AddWatched(WatchList watchList)
        {
            var result = _watchListService.ChangeWatched(watchList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _watchListService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
