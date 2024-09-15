using KPCOS.Api.Constants;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly KpcosdbContext _context;

        public AuthenticateController(KpcosdbContext kpcosdbContext)
        {
            _context = kpcosdbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResquest loginResquest)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(s => s.UserName == loginResquest.UserName && s.Password == loginResquest.Password);
            if (account == null)
                return Unauthorized(MessageConstant.LoginConstants.InvalidUsernameOrPassword);
            if (account.Status == false)
                return Problem(MessageConstant.LoginConstants.DeactivatedAccount);
            return Ok(account);
        }
        [HttpPut("register")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterDto registerDto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(s => s.UserName == registerDto.registerAccount.UserName);
            if (account != null)
                return Problem(MessageConstant.RegisterConstants.ExistUserName);
            var lastId = await _context.Accounts.OrderBy(_ => _.Id).LastOrDefaultAsync();
            return Ok(lastId?.Id);
        }
    }
}
