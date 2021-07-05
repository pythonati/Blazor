using FirstBlazor.Models;
using FirstBlazor.Models.DB;
using FirstBlazor.OtherClasses.Enum;
using System.Collections.Generic;

namespace FirstBlazor.Pages
{
    public partial class AccountPage
    {
        private void Initialized()
        {
            _model = new()
            {
                Accounts = rep_account.Items(),
                Changed = new Dictionary<AccountDBModel, DBSaveEnum>()
            };
        }
        private void Save()
        {
            if (!string.IsNullOrEmpty(_newValue))
            {
                NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
                rep_account.AddItem(new() { Name = _newValue });
            }

            foreach(var item in _model.Changed)
            {
                if(item.Value == DBSaveEnum.Edit)
                {
                    rep_account.EditItem(item.Key);
                }
            }
        }
    }
}
