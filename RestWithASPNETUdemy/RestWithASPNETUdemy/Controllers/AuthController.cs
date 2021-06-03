using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null) return Unauthorized();
            
            return Ok(token);
        }
        
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(tokenVo);

            if (token == null) return BadRequest("Invalid client request");
            
            return Ok(token);
        }
        
        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            if(User?.Identity == null)
                return BadRequest("Invalid client request");
            
            var userName = User.Identity.Name;

            var result = _loginBusiness.RevokeToken(userName);

            if (!result) return BadRequest("Invalid client request");
            
            return NoContent();
        }
    }
}