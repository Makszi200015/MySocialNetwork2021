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
    public class WebApiFriendController : ControllerBase
    {
        private readonly AccountService accountBaseFunction;
        private readonly FriendService friendService;
        private readonly UserManager<IdentityUser> user;

        public WebApiFriendController(AccountService accountBaseFunction, FriendService friendService, UserManager<IdentityUser> user)
        {
            this.accountBaseFunction = accountBaseFunction;
            this.friendService = friendService;
            this.user = user;
        }

        [HttpPost]
        [Route("Add")]
        public void Create(string login1, string login2)
        {
            if (login1 != null && login2 != null)
            {
               var accountId1 = accountBaseFunction.GetMyAccount(login1,null,"Name");
               var accountId2 = accountBaseFunction.GetMyAccount(login2, null, "Name");
               Friend friend = new Friend();
               friend.FirstAccountId = accountId1.Id;
               friend.SecondAccountId = accountId2.Id;
               var friendship = friendService.GetFriend(friend.SecondAccountId, friend.FirstAccountId);
                if (friendship != null)
                {
                    friend.State = 1;
                    friendship.State = 1;
                    friendService.Update(friendship);
                }
                else
                {
                    friend.State = 0;
                }
                friendService.Create(friend);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Friend friend)
        {
            if (friend != null)
            {
                friendService.Update(friend);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/Category/GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Friend> friends = friendService.GetList();
            if(friends != null)
            {
                return Ok(friends);
            }
            return BadRequest();
        }
    }
}
