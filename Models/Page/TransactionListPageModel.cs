using FirstBlazor.Interfaces;
using System.Collections.Generic;

namespace FirstBlazor.Models.Page
{
    public class TransactionListPageModel
    {
        public List<ITransactionListModel> Transactions { get; set; }
    }
}
