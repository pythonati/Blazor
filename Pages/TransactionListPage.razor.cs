using FirstBlazor.Models.DB;
using FirstBlazor.Models.Other;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.Pages
{
    public partial class TransactionListPage
    {
        private void Initialized()
        {
            List<AccountDBModel> accounts = rep_account.Items().ToList();

            _model.Transactions = new();

            foreach (var item in rep_trans.Items())
            {
                TransactionListModel model = new()
                {
                    Transaction = item,
                    AccountName = accounts?.FirstOrDefault(i => i.Id == item.AccountId)?.Name
                };

                _model.Transactions.Add(model);
            }
        }
    }
}
