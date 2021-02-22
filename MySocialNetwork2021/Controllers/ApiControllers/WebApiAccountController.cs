using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using MySocialNetwork2021.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiAccountController : ControllerBase
    {
        private readonly AccountService accountBaseFunction;
        private readonly UserManager<IdentityUser> user;

        public WebApiAccountController(AccountService accountBaseFunction, UserManager<IdentityUser> user)
        {
            this.accountBaseFunction = accountBaseFunction;
            this.user = user;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] Account account, string login)
        {
            var identityUser = user.FindByNameAsync(login);
            if (identityUser != null)
            {
                if (account != null)
                {
                    account.IdentityUserId = identityUser.Result.Id;
                    accountBaseFunction.Create(account);
                }
                return Ok();
            }             
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Account account)
        {
            if (account != null)
            {
                accountBaseFunction.Update(account);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/Category/GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Account> accounts = accountBaseFunction.GetList();
            if(accounts != null)
            {
                return Ok(accounts);
            }
            return BadRequest();
        }
    }
}
