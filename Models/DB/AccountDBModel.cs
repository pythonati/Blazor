using System.ComponentModel.DataAnnotations;

namespace FirstBlazor.Models.DB
{
    public class AccountDBModel
    {
        public int Id { get; set; }

        [MaxLength(500), Required]
        public string Name { get; set; }
    }
}
