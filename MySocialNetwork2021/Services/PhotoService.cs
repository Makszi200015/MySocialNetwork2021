using MySocialNetwork2021.Data;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Services
{
    public class PhotoService : IBaseFunction<Photo>
    {
        private ApplicationDbContext db;
        public AccountService accountService;
        public PhotoService(ApplicationDbContext _db, AccountService accountService)
        {
            db = _db;
            this.accountService = accountService;
        }
        public void Create(Photo item)
        {
            try
            {
                db.Photos.Add(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while activating your account");
            }
        }

        public void Delete(int id)
        {
            try
            {
                Photo photo = db.Photos.Find(id);
                db.Photos.Remove(photo);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public Photo Get(int id)
        {
            return db.Photos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Photo> GetMyPhoto(string name)
        {
            var account = accountService.GetMyAccount(name, null, "Name");
            return db.Photos.Where(x => x.AccountId == account.Id);
        }

    public IEnumerable<Photo> GetList()
    {
        try
        {
            return db.Photos.ToList();
        }
        catch
        {
            Console.WriteLine("Error");
            return null;
        }
    }

    public void Update(Photo item)
    {
        try
        {
            db.Photos.Update(item);
            db.SaveChanges();
        }
        catch
        {
            Console.WriteLine("An error occurred while updating your account");
        }
    }
}
}
