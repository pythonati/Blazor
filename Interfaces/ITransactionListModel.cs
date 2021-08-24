using FirstBlazor.Models.DB;

namespace FirstBlazor.Interfaces
{
    public interface ITransactionListModel
    {
        public TranDBModel Transaction { get; set; }
        public string LineText { get; set; }
    }
}
