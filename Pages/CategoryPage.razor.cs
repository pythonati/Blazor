using FirstBlazor.Models.DB;

namespace FirstBlazor.Pages
{
    public partial class CategoryPage
    {
        private void Initialized()
        {
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

            _selected = 0;

            if (isNeedRefreshPage)
            {
                NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
            }
        }
        private void Delete(CategoryDBModel item)
        {
            rep_category.RemoveItem(item);
            rep_category.SaveChanges();

            NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
        }
    }
}
