using FirstBlazor.Models.DB;
using System.Collections.Generic;

namespace FirstBlazor.Models.Page
{
    public class AccountPageModel
    {
        public IEnumerable<AccountDBModel> Accounts { get; set; }
    }
}
