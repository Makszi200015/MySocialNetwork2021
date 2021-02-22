using MySocialNetwork2021.Data;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Services
{
    public class NewsService : IBaseFunction<News>
    {
        private ApplicationDbContext db;
        public NewsService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Create(News item)
        {
            try
            {
                db.News.Add(item);
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
                News news = db.News.Find(id);
                db.News.Remove(news);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public News Get(int id)
        {
            return db.News.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<News> GetList()
        {
            try
            {
                return db.News.ToList();
            }
            catch
            {
                Console.WriteLine("Error");
                return null;
            }
        }

        public void Update(News item)
        {
            try
            {
                db.News.Update(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while updating your account");
            }
        }
    }
}
