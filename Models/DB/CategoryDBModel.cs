using System.ComponentModel.DataAnnotations;

namespace FirstBlazor.Models.DB
{
    public class CategoryDBModel
    {
        public int Id { get; set; }

        [MaxLength(500), Required]
        public string Name { get; set; }
    }
}
