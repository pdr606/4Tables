using _4Tables.Application.Controllers.User.Dto;
using _4Tables.Config.Auth;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.Application.Controllers.User
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<BasicResult>> Add([FromBody] CreateUserDto dto)
        {
            var result = await _userService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return StatusCode(result.Errors[0].StatusCode, result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<BasicResult>> Authenticate([FromBody] LoginUserDto dto)
        {

            var user = await _userService.FindEntityByEmail(dto.email);
            if (user == null)
            {
                return NotFound(new BasicResult().ISSUCESS(false).ERROR(new Error(System.Net.HttpStatusCode.NotFound, $"Usuário com email {dto.email} nao encontrado.")));
            }

            if (!_userService.ValidateCredentials(dto.password, user.Password, dto.email, user.Email))
            {
                return BadRequest(new BasicResult().ISSUCESS(false).ERROR(new Error(System.Net.HttpStatusCode.BadRequest, $"Senha ou email incorreto.")));
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
