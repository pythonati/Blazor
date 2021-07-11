using System;
using System.Collections.Generic;

namespace FirstBlazor.Models.DB
{
    public class TranDBModel
    {
        public int Id{ get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int Account { get; set; }
        public int Category { get; set; }
        public string Note { get; set; }
        public IEnumerable<TransLablesModel> Lables { get; set; }
    }
}
