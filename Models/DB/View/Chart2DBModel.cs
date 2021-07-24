using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazor.Models.DB.View
{
    [NotMapped]
    public class Chart2DBModel
    {
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int LabelId { get; set; }
        public string LabelName { get; set; }
    }
}
