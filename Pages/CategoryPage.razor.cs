using FirstBlazor.Models.DB;

namespace FirstBlazor.Pages
{
    public partial class CategoryPage
    {
        private void Initialized()
        {
            authUser.Authorization(navManager);

            _model = new()
            {
                Category = rep_category.Items()
            };
        }
        private void Save()
        {
            bool isNeedRefreshPage = false;

            if (!string.IsNullOrEmpty(_newValue))
            {
                rep_category.AddItem(new() { Name = _newValue });
                _newValue = "";

                isNeedRefreshPage = true;
            }

            rep_category.SaveChanges();

            if (isNeedRefreshPage)
            {
                navManager.NavigateTo(navManager.Uri, forceLoad: true);
            }
        }
        private void Delete(CategoryDBModel item)
        {
            rep_category.RemoveItem(item);
            rep_category.SaveChanges();

            navManager.NavigateTo(navManager.Uri, forceLoad: true);
        }
    }
}
