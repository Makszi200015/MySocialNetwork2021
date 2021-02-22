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
    public class WebApiPhotoAlbumController : ControllerBase
    {
        private readonly AccountService accountBaseFunction;
        private readonly PhotoAlbumService photoAlbumService;
        private readonly PhotoService photoService;
        private readonly UserManager<IdentityUser> user;

        public WebApiPhotoAlbumController(AccountService accountBaseFunction, PhotoAlbumService photoAlbumService, PhotoService photoService, UserManager<IdentityUser> user)
        {
            this.accountBaseFunction = accountBaseFunction;
            this.photoAlbumService = photoAlbumService;
            this.photoService = photoService;
            this.user = user;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(string photoAlbumName, int[] checkedPhotos)
        {
            if (photoAlbumName != null && checkedPhotos != null)
            {
                foreach (var item in checkedPhotos)
                {
                    var photo = photoService.Get(item);
                    if (photo != null)
                    {
                        PhotoAlbum photoAlbum = new PhotoAlbum();
                        photoAlbum.Photos.Add(photo);
                        photoAlbum.AlbumName = photoAlbumName;
                        photoAlbum.AccountId = photo.AccountId;
                        photoAlbumService.Create(photoAlbum);
                        var photoIn = photoService.Get(item);
                        if (photoIn != null)
                        {
                            photoIn.PhotoAlbumId = photoAlbum.Id;
                            photoService.Update(photoIn);
                        }
                    }
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(int id, int[] checkedPhotos)
        {
            if (checkedPhotos != null)
            {
                foreach (var item in checkedPhotos)
                {
                    var photo = photoService.Get(item);
                    if (photo != null)
                    {
                        var photoAlbum = photoAlbumService.Get(id);
                        if (photoAlbum != null)
                        {
                            photoAlbum.Photos.Add(photo);
                            photoAlbumService.Update(photoAlbum);
                        }
                        var photoIn = photoService.Get(item);
                        if (photoIn != null)
                        {
                            photoIn.PhotoAlbumId = photoAlbum.Id;
                            photoService.Update(photoIn);
                        }
                    }
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/Category/GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<PhotoAlbum> albums = photoAlbumService.GetList();
            if (albums != null)
            {
                return Ok(albums);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeletePhoto(int[] photos)
        {
            if (photos != null)
            {
                foreach (var item in photos)
                {
                    photoAlbumService.Delete(item);
                    var photo = photoService.Get(item);
                    if (photo != null)
                    {
                        photo.PhotoAlbumId = null;
                        photoService.Update(photo);
                    }
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}