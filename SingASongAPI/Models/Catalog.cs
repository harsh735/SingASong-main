﻿namespace SingASongAPI.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public decimal AlbumPrice { get; set; }
        public double AlbumRating { get; set; }

        public string AlbumGenre { get; set; }
    }

}
