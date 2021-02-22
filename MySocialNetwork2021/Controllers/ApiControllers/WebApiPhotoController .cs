using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using MySocialNetwork2021.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiPhotoController : ControllerBase
    {
        private readonly AccountService accountBaseFunction;
        private readonly PhotoService photoService;
        private readonly PhotoAlbumService photoAlbumService;
        private readonly UserManager<IdentityUser> user;
        IWebHostEnvironment _appEnvironment;
        public WebApiPhotoController(AccountService accountBaseFunction, PhotoService photoService, PhotoAlbumService photoAlbumService, UserManager<IdentityUser> user, IWebHostEnvironment _appEnvironment)
        {
            this.accountBaseFunction = accountBaseFunction;
            this.photoService = photoService;
            this.photoAlbumService = photoAlbumService;
            this.user = user;
            this._appEnvironment = _appEnvironment;
    }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var account = accountBaseFunction.GetMyAccount(User.Identity.Name ,null,"Name");
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                     uploadedFile.CopyTo(fileStream);
                }
                if(account != null)
                {
                    Photo photo = new Photo { Name = "/Files/" + uploadedFile.FileName, AccountId = account.Id };
                    photoService.Create(photo);
                }    
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int[] photos)
        {
            {
                if(photos != null)
                {
                    foreach (var item in photos)
                    {
                        photoService.Delete(item);
                    }
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
