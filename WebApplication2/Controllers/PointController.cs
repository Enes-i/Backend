using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly PointService _pointService;

        public PointController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public ActionResult<Response<List<Point>>> GetAll()
        {
            var points = _pointService.GetAll();
            return Ok(new Response<List<Point>> { Value = points, ValueStatus = true, Message = "Points retrieved successfully." });
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Point>> GetById(long id)
        {
            var point = _pointService.GetById(id);
            if (point == null)
            {
                return NotFound(new Response<Point> { Value = null, ValueStatus = false, Message = "Point not found." });
            }
            return Ok(new Response<Point> { Value = point, ValueStatus = true, Message = "Point retrieved successfully." });
        }

        [HttpPost]
        public ActionResult<Response<Point>> Add(Point point)
        {
            var addedPoint = _pointService.Add(point);
            return Ok(new Response<Point> { Value = addedPoint, ValueStatus = true, Message = "Point added successfully." });
        }

        [HttpPut("{id}")]
        public ActionResult<Response<string>> Update(long id, Point point)
        {
            var success = _pointService.Update(id, point);
            if (!success)
            {
                return NotFound(new Response<string> { Value = null, ValueStatus = false, Message = "Point not found." });
            }

            return Ok(new Response<string> { Value = "Update successful", ValueStatus = true, Message = "Point updated successfully." });
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<string>> Delete(long id)
        {
            var success = _pointService.Delete(id);
            if (!success)
            {
                return NotFound(new Response<string> { Value = null, ValueStatus = false, Message = "Point not found." });
            }

            return Ok(new Response<string> { Value = "Delete successful", ValueStatus = true, Message = "Point deleted successfully." });
        }
    }
}
