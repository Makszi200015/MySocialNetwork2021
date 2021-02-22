using MySocialNetwork2021.Data;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MySocialNetwork2021.Models.UserOrFriendModel;

namespace MySocialNetwork2021.Services
{
    public class BanService : IBaseFunction<Ban>
    {
        private readonly AccountService accountService;
        private ApplicationDbContext db;
        public BanService(ApplicationDbContext _db, AccountService accountService)
        {
            db = _db;
            this.accountService = accountService;
        }
        public void Create(Ban item)
        {
            try
            {
                db.Bans.Add(item);
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
                Ban ban = db.Bans.Find(id);
                db.Bans.Remove(ban);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public Ban Get(int id)
        {
            return db.Bans.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Ban> GetList()
        {
            try
            {
                return db.Bans.ToList();
            }
            catch
            {
                Console.WriteLine("Error");
                return null;
            }
        }

        public void Update(Ban item)
        {
            try
            {
                db.Bans.Update(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while updating your account");
            }
        }

        public Ban GetFriend(int firstAccountId, int secondAccountId)
        {
            try
            {
                return db.Bans.FirstOrDefault(x => x.FirstAccountId == firstAccountId && x.SecondAccountId == secondAccountId);
            }
            catch
            {
                return null;
            }
        }       
    }
}
