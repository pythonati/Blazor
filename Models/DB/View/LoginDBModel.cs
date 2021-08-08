using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazor.Models.DB.View
{
    [NotMapped]
    public class LoginDBModel
    {
        public int UserId { get; set; }
    }
}

