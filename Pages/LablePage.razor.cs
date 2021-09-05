using FirstBlazor.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Pages
{
    public partial class LablePage
    {
        private void Initialized()
        {
            authUser.Authorization(navManager);

            _model = new()
            {
                Lables = rep_lable.Items()
            };
        }
        private void Save()
        {
            bool isNeedRefreshPage = false;

            if (!string.IsNullOrEmpty(_newValue))
            {
                rep_lable.AddItem(new() { Name = _newValue });
                _newValue = "";

                isNeedRefreshPage = true;
            }

            rep_lable.SaveChanges();

            if (isNeedRefreshPage)
            {
                navManager.NavigateTo(navManager.Uri, forceLoad: true);
            }
        }
        private void Delete(LableDBModel item)
        {
            rep_lable.RemoveItem(item);
            rep_lable.SaveChanges();

            navManager.NavigateTo(navManager.Uri, forceLoad: true);
        }
    }
}
