using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorImageController : ControllerBase
    {
        IDirectorImageService _directorImageService;

        public DirectorImageController(IDirectorImageService directorImageService)
        {
            _directorImageService = directorImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _directorImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] DirectorImage directorImage)
        {
            var result = _directorImageService.Add(file, directorImage);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] DirectorImage directorImage)
        {
            var result = _directorImageService.Update(file, directorImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int id) 
        {
            var result = _directorImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetByDirectorId")]
        public IActionResult GetByDirectorId(int id)
        {
            var result = _directorImageService.GetByDirectorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _directorImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
