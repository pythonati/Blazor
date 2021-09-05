using FirstBlazor.Models.DB.View;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.OtherClasses
{
    public class AuthorizationClass
    {
        private List<UserUrlDBModel> _availableUrls = new();
        public int Id { get; set; }
        public void Authorization(NavigationManager navManager)
        {
            if (navManager is null)
            {
                navManager.NavigateTo("/login");
                return;
            }
            //Если пользователь не Идентифицирован, то отправляем на страницу Login
            if (Id == 0)
            {
                navManager.NavigateTo("/login");
                return;
            }

            //Это надо проверить на корректность логики проверки Url
            if (!_availableUrls.Exists(i => (navManager.Uri + '/').ToUpper().Contains((navManager.BaseUri + i.Url + '/').ToUpper())))
            {
                navManager.NavigateTo("/login");
                return;
            }
        }
        public void Refresh(IEnumerable<UserUrlDBModel> _urls)
        {
            if (_urls is null)
            {
                _availableUrls.Clear();
                return;
            }

            //Здесь получаем список сайтов которые доступны пользователю
            _availableUrls = _urls.ToList();
        }
    }
}
