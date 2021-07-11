using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazor.Models.DB
{
    public class TransLablesModel
    {
        public int TransactionId { get; set; }
        public TranDBModel Transaction { get; set; }
        public int LableId { get; set; }
        public LableDBModel Lable { get; set; }
    }
}
