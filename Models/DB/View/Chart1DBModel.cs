using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazor.Models.DB.View
{
    [NotMapped]
    public class Chart1DBModel
    {
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
