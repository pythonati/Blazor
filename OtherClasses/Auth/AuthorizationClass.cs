using FirstBlazor.Models.DB.View;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.OtherClasses
{
    public class AuthorizationClass
    {
        private List<UserUrlDBModel> _availableUrls = new();
        public int Id { get; set; }
        public bool Authorization(string _url)
        {
            //Если пользователь не Идентифицирован, то отправляем на страницу Login
            if (Id == 0)
            {
                //                navManager.NavigateTo("/login");
                return true;
            }

            //Это надо проверить на корректность логики проверки Url
            return _availableUrls.Exists(i => _url.ToUpper().Contains(i.Url));
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
