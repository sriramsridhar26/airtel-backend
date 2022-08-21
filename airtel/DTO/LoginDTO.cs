namespace airtel.DTO
{
    public class LoginDTO
    {
        public long customerId { get; set; }
        public string password { get; set; }


    }
    public class UserDTO : LoginDTO
    {
        public string customerName { get; set; }
    }
}
