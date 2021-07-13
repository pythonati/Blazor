using FirstBlazor.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
