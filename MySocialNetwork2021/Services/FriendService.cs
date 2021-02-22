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
    public class FriendService : IBaseFunction<Friend>
    {
        private readonly AccountService accountService;
        private readonly BanService banService;
        private ApplicationDbContext db;
        public FriendService(ApplicationDbContext _db, AccountService accountService, BanService banService)
        {
            db = _db;
            this.accountService = accountService;
            this.banService = banService;
        }
        public void Create(Friend item)
        {
            try
            {
                db.Friends.Add(item);
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
                Friend friend = db.Friends.Find(id);
                db.Friends.Remove(friend);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }

        public Friend Get(int id)
        {
            return db.Friends.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Friend> GetList()
        {
            try
            {
                return db.Friends.ToList();
            }
            catch
            {
                Console.WriteLine("Error");
                return null;
            }
        }

        public void Update(Friend item)
        {
            try
            {
                db.Friends.Update(item);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("An error occurred while updating your account");
            }
        }

        public Friend GetFriend(int firstAccountId, int secondAccountId)
        {
            try
            {
                return db.Friends.FirstOrDefault(x => x.FirstAccountId == firstAccountId && x.SecondAccountId == secondAccountId);
            }
            catch
            {
                return null;
            }
        }
        public List<UserOrFriendModel> GetStatusFriends(string login)
        {
            List<UserOrFriendModel> sortUser = new List<UserOrFriendModel>();
            Account account = accountService.GetMyAccount(login, null, "Name");
            var sortFriends = db.Friends.ToList();
            var allUsers = accountService.GetList();
            if (account != null)
            {
                foreach (var item in allUsers)
                {
                    if (item.Id != account.Id)
                    {
                        sortUser.Add(new UserOrFriendModel { Id = item.Id, Username = item.AccountName });
                    }
                }
            }
            return GetUserStatusByMyAccount(account.Id, sortUser, sortFriends);
        }

        public List<UserOrFriendModel> GetUserStatusByMyAccount(int myId, List<UserOrFriendModel> sortUser, List<Friend> sortFriends)
        {
            var ban = banService.GetList();
            foreach (var user in sortUser)
            {
                if (sortFriends.Count() != 0)
                {
                    if (sortFriends.FirstOrDefault(x => x.FirstAccountId == user.Id &&
                    x.SecondAccountId == myId && x.State == 0) != null)
                    {
                        user.Status = (int)UserStatus.Subscriber;
                    }
                    else if (sortFriends.FirstOrDefault(x => x.SecondAccountId == user.Id &&
                    x.FirstAccountId == myId && x.State == 0) != null)
                    {
                        user.Status = (int)UserStatus.ToSubscribe;
                    }
                    else if (sortFriends.FirstOrDefault(x => x.FirstAccountId == user.Id && x.SecondAccountId == myId && x.State == 1) != null &&
                        sortFriends.FirstOrDefault(x => x.SecondAccountId == user.Id && x.FirstAccountId == myId && x.State == 1) != null)
                    {
                        user.Status = (int)UserStatus.Friend;
                    }
                    else
                    {
                        user.Status = (int)UserStatus.Free;
                    }
                }
                if (ban !=null && ban.Where(x => x.FirstAccountId == myId || x.SecondAccountId == myId) != null)
                {
                    if (ban.FirstOrDefault(x => x.FirstAccountId == myId && x.SecondAccountId == user.Id) != null)
                    {
                        user.IsBun = true;
                    }
                    else if (ban.FirstOrDefault(x => x.FirstAccountId == user.Id && x.SecondAccountId == myId) != null)
                    {
                        user.IInBun = true;
                    }
                }
            }
            return sortUser;
        }
    }
}
