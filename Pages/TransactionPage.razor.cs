﻿using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using FirstBlazor.OtherClasses;
using System;

namespace FirstBlazor.Pages
{
    public partial class TransactionPage
    {
        private void Initialized()
        {
            if (id == 0)
            {
                CreateNewTransaction();
            }
            else
            {
                _model.Transaction = rep_trans.GetItemById(id);

                if(_model.Transaction is null)
                {
                    CreateNewTransaction();
                }

                if(_model.Transaction.Lables is null)
                {
                    _model.Transaction.Lables = new();
                }
            }
        }
        private void CreateNewTransaction()
        {
            AccountDBModel account = rep_account.GetFirstItem();
            CategoryDBModel category = rep_category.GetFirstItem();

            _model.Transaction = new()
            {
                AccountId = account?.Id ?? 0,
                CategoryId = category?.Id ?? 0,
                Amount = 0,
                Date = System.DateTime.Now,
                Note = "",
                Lables = new()
            };
        }
        private void Save()
        {
            _model.Transaction.Amount = Math.Abs(_model.Transaction.Amount);

            if (_selectedTab == 1)
            {
                _model.Transaction.Amount = -_model.Transaction.Amount;
            }

            if (_model.Transaction.Id == 0)
            {
                rep_trans.AddItem(_model.Transaction);
            }

            rep_trans.SaveChanges();
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
        private void RemoveLable(TransLablesModel item)
        {
            _model.Transaction.Lables.Remove(item);
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
