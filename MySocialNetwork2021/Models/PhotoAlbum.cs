using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class PhotoAlbum
    {
        [Key]
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int AccountId { get; set; }
        public Account account { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
    }
}
