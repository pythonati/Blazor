using FirstBlazor.OtherClasses.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazor.Models.DB.View
{
    [NotMapped]
    public class LoginDBModel
    {
        public LoginResults Result { get; set; }
        public int UserId { get; set; }
    }
}

