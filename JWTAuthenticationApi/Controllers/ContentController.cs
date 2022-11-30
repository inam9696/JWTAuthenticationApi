using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace JWTAuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {

        [HttpGet("getWithCookie")]
        public IActionResult GetWithCookie()
        {
            var userName = HttpContext.User.Claims
                    .Where(x => x.Type == ClaimTypes.Name)
                    .Select(x => x.Value)
                    .FirstOrDefault();
            return Content($"<p>Hello to Code Maze {userName}</p>");
        }


        
        //[Authorize]
        //[HttpGet("getWithAny")]
        
        //public IActionResult GetWithAny()
        //{
        //    return Ok(new { Message = $"Hello to Code Maze {GetUsername()}" });
        //}

        //private object GetUsername()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
