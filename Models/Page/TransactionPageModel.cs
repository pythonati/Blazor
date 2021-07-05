using FirstBlazor.OtherClasses.Enum;
using System;

namespace FirstBlazor.Models.Page
{
    public class TransactionPageModel
    {
        public DBSaveEnum Action { get; set; }
        public int Account { get; set; }
        public int Category { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
