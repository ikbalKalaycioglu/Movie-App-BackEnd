using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarImageController : ControllerBase
    {
        IStarImageService _starImageService;

        public StarImageController(IStarImageService starImageService)
        {
            _starImageService = starImageService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] StarImage starImage)
        {
            var result = _starImageService.Add(file, starImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _starImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] StarImage starImage)
        {
            var result = _starImageService.Update(file, starImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _starImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByStarId")]
        public IActionResult GetByStarId(int starId)
        {
            var result = _starImageService.GetByStarId(starId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByStarImageId")]
        public IActionResult GetByStarImageId(int starImageId)
        {
            var result = _starImageService.GetByStarImageId(starImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
