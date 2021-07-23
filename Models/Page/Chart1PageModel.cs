using FirstBlazor.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Models.Page
{
    public class Chart1PageModel
    {
        private static Chart1PageModel _this;
        public Params Params { get; set; } = new();

        private Chart1PageModel(){}
        public static Chart1PageModel GetInstance()
        {
            if (_this is null)
            {
                _this = new();
            }

            return _this;
        }
    }

    public class Params
    {
        public DateTime DateFrom { get; set; } = DateTime.Now;
        public DateTime DateTo { get; set; } = DateTime.Now;
        public HashSet<AccountDBModel> SelectedAccounts { get; set; } = new();
        public HashSet<CategoryDBModel> SelectedCategory { get; set; } = new();
    }
}
