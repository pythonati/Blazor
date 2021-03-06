using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.OtherClasses
{
    public static class List_TransLablesModel_Extension
    {
        public static bool AddUniqLable(this List<TransLablesModel> _this, TransLablesModel item)
        {
            if(_this.Count<TransLablesModel>(i => i.LableId == item.LableId) == 0)
                {
                    _this.Add(item);

                return true;
            }

            return false;
        }
        public static bool ContainsLable(this List<TransLablesModel> _this, LableDBModel item)
        {
            if (_this.Count<TransLablesModel>(i => i.LableId == item.Id) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
