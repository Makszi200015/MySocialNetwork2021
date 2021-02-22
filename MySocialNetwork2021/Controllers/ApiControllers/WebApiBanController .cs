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
    public class WebApiBanController : ControllerBase
    {
        private readonly AccountService accountBaseFunction;
        private readonly BanService banService;
        private readonly UserManager<IdentityUser> user;

        public WebApiBanController(AccountService accountBaseFunction, BanService banService, UserManager<IdentityUser> user)
        {
            this.accountBaseFunction = accountBaseFunction;
            this.banService = banService;
            this.user = user;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(string login1, string login2)
        {
            if (login1 != null && login2 != null)
            {
               var accountId1 = accountBaseFunction.GetMyAccount(login1,null,"Name");
               var accountId2 = accountBaseFunction.GetMyAccount(login2, null, "Name");
               Ban ban = new Ban();
               ban.FirstAccountId = accountId1.Id;
               ban.SecondAccountId = accountId2.Id;       
               banService.Create(ban);
               return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Ban ban)
        {
            if (ban != null)
            {
                banService.Update(ban);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/Category/GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Ban> bans = banService.GetList();
            if(bans != null)
            {
                return Ok(bans);
            }
            return BadRequest();
        }
    }
}
