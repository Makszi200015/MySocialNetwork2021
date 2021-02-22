using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int? PhotoAlbumId { get; set; }
        public PhotoAlbum PhotoAlbum { get; set; }

    }
}
