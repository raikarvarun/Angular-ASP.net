using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        public string CardHolderName { get; set; }
        public string CardHolderNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVV { get; set; }

    }
}
