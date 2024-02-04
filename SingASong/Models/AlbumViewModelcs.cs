namespace SingASong.Models
{
    public class Album
    {
        public int albumID { get; set; }
        public string albumName { get; set; }
        public string artistName { get; set; }
        //public DateTime AlbumDate { get; set; }
        public decimal albumPrice { get; set; }
        public decimal albumRating { get; set; }

        public string? albumGenre { get; set; }

    }
}
