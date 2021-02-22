using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AvatarPhoto { get; set; }
        public int? FriendsCount { get; set; }
        public int? SubscriberCount { get; set; }
        public int? PostCount { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
