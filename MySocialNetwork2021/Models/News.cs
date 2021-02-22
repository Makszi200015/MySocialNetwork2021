using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
