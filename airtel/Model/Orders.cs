using System.ComponentModel.DataAnnotations;

namespace airtel.Model
{
    public class Orders
    {
        [Key]
        public int? orderId { get; set; }
        public long customerId { get; set; }
        public int packId { get; set; }
        public string packName { get; set; }
        public int price { get; set; }
        public bool? purchased { get; set; }
    }
}
