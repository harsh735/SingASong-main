namespace SingASong.Models
{
    public class User
    {
        public int userID { get; set; }

        public string userName { get; set; }


        public string userEmail { get; set; }
        public string userPhoneNo { get; set; }
        public string userAddress { get; set; }

        public string userPassword { get; set; }
        public bool isAdmin { get; set; }

    }
}
