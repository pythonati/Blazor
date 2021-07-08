using FirstBlazor.Models.DB;
using FirstBlazor.OtherClasses.Enum;
using System.Collections.Generic;

namespace FirstBlazor.Models.Page
{
    public class CategoryPageModel
    {
        public IEnumerable<CategoryDBModel> Category { get; set; }
    }
}
