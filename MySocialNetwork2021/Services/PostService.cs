using MySocialNetwork2021.Data;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Services
{
    public class PostService : IBaseFunction<Post>
    {
        private ApplicationDbContext db;
        public PostService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Create(Post item)
        {
            try
            {
                db.Posts.Add(item);
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
                Post post = db.Posts.Find(id);
                db.Posts.Remove(post);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public Post Get(int id)
        {
            return db.Posts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Post> GetSortList(string accountName)
        {
            try
            {
               Account account = db.Accounts.FirstOrDefault(x => x.AccountName == accountName);
                return db.Posts.Where(x => x.AccountId == account.Id);
            }
            catch
            {
                Console.WriteLine("Error");
                return null;
            }
        }

        public IEnumerable<Post> GetList()
        {
            try
            {
                return db.Posts.ToList();
            }
            catch
            {
                return null;
            }
        }

        public void Update(Post item)
        {
            try
            {
                db.Posts.Update(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while updating your account");
            }
        }
    }
}
