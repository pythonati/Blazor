using System.ComponentModel.DataAnnotations;

namespace FirstBlazor.Models.DB
{
    public class AccountDBModel
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }
    }
}
