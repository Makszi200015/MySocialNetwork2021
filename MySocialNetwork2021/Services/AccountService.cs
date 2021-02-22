using Microsoft.AspNetCore.Identity;
using MySocialNetwork2021.Data;
using MySocialNetwork2021.Interfaces;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Services
{
    public class AccountService : IBaseFunction<Account>
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> user;
        public AccountService(ApplicationDbContext _db, UserManager<IdentityUser> _user)
        {
            db = _db;
            user = _user;
        }
        public void Create(Account item)
        {
            try
            {
                db.Accounts.Add(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while activating your account");
            }
        }

        public void Delete(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }

        public IEnumerable<Account> GetList()
        {
            try
            {
                return db.Accounts.ToList();
            }
            catch
            {
                Console.WriteLine("Error");
                return null;
            }

        }

        public Account GetMyAccount(string Name, int? id, string propertyName)
        {
            Account account = new Account();
            switch (propertyName)
            {
                case "Id":
                    account = db.Accounts.FirstOrDefault(x => x.Id == id);
                    break;
                case "Name":
                    account = db.Accounts.FirstOrDefault(x => x.AccountName == Name);
                    break;
            }
            return account;
        }

        public void Update(Account item)
        {
            try
            {
                db.Accounts.Update(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while updating your account");
            }

        }

        public Account Get(int id)
        {
            return db.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public bool IsAccountExist(string login)
        {
            try
            {
                return db.Accounts.Any(x => x.AccountName == login);
            }
            catch
            {
                Console.WriteLine("Error");
                return false;
            }
        }
    }
}
