using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class UserOrFriendModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Status { get; set; }
        public enum UserStatus
        {
            Free = 1,
            Subscriber,
            ToSubscribe,
            Friend
        }
        public bool IsBun { get; set; }
        public bool IInBun { get; set; }
    }
}
