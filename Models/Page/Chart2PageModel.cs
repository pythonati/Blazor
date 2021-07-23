using FirstBlazor.Models.DB;
using System;
using System.Collections.Generic;

namespace FirstBlazor.Models.Page
{
    public class Chart2PageModel
    {
        private static Chart2PageModel _this;
        public ParamsClass Params { get; set; } = new();

        private Chart2PageModel() { }
        public static Chart2PageModel GetInstance()
        {
            if (_this is null)
            {
                _this = new();
            }

            return _this;
        }

        public class ParamsClass
        {
            public DateTime DateFrom { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
            public DateTime DateTo { get; set; } = DateTime.Now;
            public HashSet<AccountDBModel> SelectedAccounts { get; set; } = new();
            public HashSet<CategoryDBModel> SelectedCategory { get; set; } = new();
            public HashSet<LableDBModel> SelectedLabels { get; set; } = new();
        }
    }
}
