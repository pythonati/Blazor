using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using FirstBlazor.OtherClasses;

namespace FirstBlazor.Pages
{
    public partial class TransactionPage
    {
        private void Initialized()
        {
            _model.Transaction = new()
            {
                Account = rep_account.GetFirstItem()?.Id ?? 0,
                Category = rep_category.GetFirstItem()?.Id ?? 0,
                Amount = 0,
                Date = System.DateTime.Now,
                Note = "",
                Lables = new()
            };
        }
        private void Save()
        {
            /*            TranDBModel item = new()
                        {
                            Date = _model.Date,
                            Amount = _model.Amount,
                            Account = _model.Account,
                            Category = _model.Category,
                            Note = _model.Note
                        };

                        if (_model.Action == DBSaveEnum.Add)
                            rep_trans.AddItem(item);

                        if (_model.Action == DBSaveEnum.Edit)
                            rep_trans.EditItem(item);*/
        }
        private void Add_RemoveSelectedLable(LableDBModel item)
        {
            if (_selectedLables.Contains(item))
            {
                _selectedLables.Remove(item);
            }
            else
            {
                _selectedLables.Add(item);
            }
        }
        private void AddLables()
        {
            foreach (var item in _selectedLables)
            {
                TransLablesModel transLableModel = new()
                {
                    Transaction = _model.Transaction,
                    TransactionId = _model.Transaction.Id,
                    Lable = item,
                    LableId = item.Id
                };

                _model.Transaction.Lables.AddUniqLable(transLableModel);
            }
        }
        public class SaveButton : IText, IStyle
        {
            public string GetText => "Сохранить";

            public string GetStyle => "btn btn-light btn-block";
        }

        public class IncomeButton : IText, IStyle
        {
            private int _id;
            private int _selected;

            public IncomeButton(int id)
            {
                _id = id;
            }
            public IncomeButton setSelected(int val)
            {
                _selected = val;

                return this;
            }
            public string GetStyle
            {
                get
                {
                    if (_selected == _id)
                    {
                        return "btn btn-ati-trans-income-disable bcolor bcolor-ati-white fcolor-ati-green col-6";
                    }

                    return "btn btn-ati-trans-income-action bcolor-ati-orange fcolor-ati-white col-6";
                }
            }

            public string GetText => "Доход";
        }
        public class SpendButton : IText, IStyle
        {
            private int _id;
            private int _selected;

            public SpendButton(int id)
            {
                _id = id;
            }
            public SpendButton setSelected(int val)
            {
                _selected = val;

                return this;
            }
            public string GetStyle
            {
                get
                {
                    if (_selected == _id)
                    {
                        return "btn btn-ati-trans-spend-disable bcolor bcolor-ati-white fcolor-ati-orange";
                    }

                    return "btn btn-ati-trans-spend-action bcolor-ati-green fcolor-ati-white";
                }
            }

            public string GetText => "Расход";
        }
        public class DivBGColor : IStyle
        {
            private int _selected;

            public DivBGColor setSelected(int val)
            {
                _selected = val;

                return this;
            }
            public string GetStyle
            {
                get
                {
                    if (_selected == 1)
                    {
                        return "bcolor-ati-orange";
                    }

                    return "bcolor-ati-green";
                }
            }
        }
    }
}
