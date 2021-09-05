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
            authUser.Authorization(navManager);

            List<AccountDBModel> accounts = rep_account.Items().ToList();

            _model.Transactions = new();

            foreach (var item in rep_trans.Items())
            {
                TransactionListModel model = new()
                {
                    Transaction = item,
                    LineText = accounts?.FirstOrDefault(i => i.Id == item.AccountId)?.Name + ": " + item.Note
                };

                _model.Transactions.Add(model);
            }
        }
        private void DeleteTran(TranDBModel item)
        {
            rep_trans.RemoveItem(item);
            rep_trans.SaveChanges();

            navManager.NavigateTo(navManager.Uri, forceLoad: true);
        }
    }
}
