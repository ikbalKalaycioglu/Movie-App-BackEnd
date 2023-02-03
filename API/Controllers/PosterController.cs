using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosterController : ControllerBase
    {
        IPosterService _posterService;

        public PosterController(IPosterService posterService)
        {
            _posterService = posterService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] Poster poster)
        {
            var result = _posterService.Add(file, poster);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _posterService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Poster poster)
        {
            var result = _posterService.Update(file, poster);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _posterService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByContentId")]
        public IActionResult GetByCarId(int contentId)
        {
            var result = _posterService.GetByContentId(contentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByPosterId")]
        public IActionResult GetByImageId(int posterId)
        {
            var result = _posterService.GetByPosterId(posterId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
