using MySocialNetwork2021.Data;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Services
{
    public class PhotoAlbumService : IBaseFunction<PhotoAlbum>
    {
        private ApplicationDbContext db;
        private AccountService AccountService;
        public PhotoAlbumService(ApplicationDbContext _db, AccountService AccountService)
        {
            db = _db;
            this.AccountService = AccountService;
        }
        public void Create(PhotoAlbum item)
        {
            //try
            //{
                db.PhotoAlbums.Add(item);
                db.SaveChanges();
            }
            //catch
            //{
            //    Console.WriteLine("An error occurred while activating your account");
            //}
        //}

        public void Delete(int id)
        {
            try
            {
                PhotoAlbum photoAlbum = db.PhotoAlbums.Find(id);
                db.PhotoAlbums.Remove(photoAlbum);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public PhotoAlbum Get(int id)
        {
            return db.PhotoAlbums.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<PhotoAlbum> GetList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhotoAlbum> GetSortList(string name)
        {
            try
            {
                var account = AccountService.GetMyAccount(name,null,"Name");
                return db.PhotoAlbums.Where(x => x.AccountId == account.Id);
            }
            catch
            {
                Console.WriteLine("Error");
                return null;
            }
        }

        public void Update(PhotoAlbum item)
        {
            try
            {
                db.PhotoAlbums.Update(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while updating your account");
            }
        }
    }
}
