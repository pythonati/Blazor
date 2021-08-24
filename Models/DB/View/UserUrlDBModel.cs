using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazor.Models.DB.View
{
    [NotMapped]
    public class UserUrlDBModel
    {
        public string Url { get; set; }
    }
}

