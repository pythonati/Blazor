using FirstBlazor.Models.DB;
using FirstBlazor.OtherClasses.Enum;
using System.Collections.Generic;

namespace FirstBlazor.Models.Page
{
    public class AccountPageModel
    {
        public IEnumerable<AccountDBModel> Accounts { get; set; }
    }
}
