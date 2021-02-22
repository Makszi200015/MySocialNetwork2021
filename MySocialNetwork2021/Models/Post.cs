using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Text { get; set; }
        public string Video { get; set; }
        public string Photo { get; set; }
        public string Audio { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
