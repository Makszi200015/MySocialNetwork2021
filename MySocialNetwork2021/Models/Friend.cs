using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        public int FirstAccountId { get; set; }
        public int SecondAccountId { get; set; }
        public Account Account { get; set; }
        public int State { get; set; }
    }
}
