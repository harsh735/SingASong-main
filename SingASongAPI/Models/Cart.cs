namespace SingASongAPI.Models
{
    public class Cart
    {
        public int cartID { get; set; }
        public int userID { get; set; }
        public int albumID { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

        public List<Album> cartAlbum { get; set; }
    }
}
