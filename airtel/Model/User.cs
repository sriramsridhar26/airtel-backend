using System.ComponentModel.DataAnnotations;

namespace airtel.Model
{
    public class User
    {
        [Key]
        public long customerId { get; set; }
        public string password { get; set; }
        public string customerName { get; set; }
    }
}
