using System.ComponentModel.DataAnnotations;

namespace airtel.Model
{
    public class Packs
    {

        [Key]
        public int packId { get; set; }
        [Required]
        public string PackTag { get; set; }
        [Required]
        public string PackName { get; set; }

        public string Talktime { get; set; }
        public string Sms { get; set; }
        public string data { get; set; }
        public int cost { get; set; }
        public int validity { get; set; }
    }
}
