using FirstBlazor.Models;
using FirstBlazor.Models.DB;
using System.Collections.Generic;

namespace FirstBlazor.Pages
{
    public partial class AccountPage
    {
        private void Initialized()
        {
            authUser.Authorization(navManager.Uri);

            _model = new()
            {
                Accounts = rep_account.Items()
            };
        }
        private void Save()
        {
            bool isNeedRefreshPage = false;

            if (!string.IsNullOrEmpty(_newValue))
            {
                rep_account.AddItem(new() { Name = _newValue });
                _newValue = "";

                isNeedRefreshPage = true;
            }

            rep_account.SaveChanges();

            if (isNeedRefreshPage)
            {
                navManager.NavigateTo(navManager.Uri, forceLoad: true);
            }
        }
        private void Delete(AccountDBModel item)
        {
            rep_account.RemoveItem(item);
            rep_account.SaveChanges();

            navManager.NavigateTo(navManager.Uri, forceLoad: true);
        }
    }
}
