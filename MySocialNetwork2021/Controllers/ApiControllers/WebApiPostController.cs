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
    public class WebApiPostController : ControllerBase
    {
        private readonly PostService postService;
        private readonly AccountService accountService;
        private readonly NewsService newsService;
        private readonly UserManager<IdentityUser> user;

        public WebApiPostController(PostService postService, AccountService accountService, NewsService newsService, UserManager<IdentityUser> user)
        {
            this.postService = postService;
            this.accountService = accountService;
            this.newsService = newsService;
            this.user = user;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] Post post, string login)
        {
            Account account = accountService.GetMyAccount(login, null, "Name");
            if (account != null)
            {
                if (post != null)
                {
                    News news = new News();
                    post.AccountId = account.Id;
                    postService.Create(post);
                    news.Posts.Add(post);
                    newsService.Create(news);
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(int id, string newPost)
        {
            if (newPost != null)
            {
                var post = postService.Get(id);
                if (post != null)
                {
                    post.Text = newPost;
                    postService.Update(post);
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int[] posts)
        {
            if (posts != null)
            {
                foreach (var item in posts)
                {
                    postService.Delete(item);
                }
                return Ok();
            }

            return BadRequest();
        }
    }
}
