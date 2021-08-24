using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;

namespace FirstBlazor.Models.Other
{
    public class TransactionListModel : ITransactionListModel
    {
        public TranDBModel Transaction { get; set; }
        public string LineText { get; set; }
    }
}
