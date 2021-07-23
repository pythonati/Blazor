using FirstBlazor.Models.DB;
using FirstBlazor.Models.DB.View;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.Features.Dashboard.Chart2
{
    public partial class Chart2Page
    {
        private void Initialized()
        {
            CreateChartData();
        }
        private IEnumerable<Chart1DBModel> getData()
        {
            string accounts = "";
            string category = "";

            foreach (var item in _model.Params.SelectedAccounts)
            {
                accounts += item.Id + ", ";
            }

            foreach (var item in _model.Params.SelectedCategory)
            {
                category += item.Id + ", ";
            }

            var _params = new Dictionary<string, string>(4);

            _params.Add("dateFrom", _model.Params.DateFrom.ToString("yyyy-MM-dd"));
            _params.Add("dateTo", _model.Params.DateTo.ToString("yyyy-MM-dd"));
            _params.Add("accountTypes", accounts);
            _params.Add("categoryTypes", category);

            return rep_chart.Items(_params);
        }
        private void CreateChartData()
        {
            List<string> _lables = new();
            List<double> _data = new();

            foreach (var item in getData())
            {
                _lables.Add(item.CategoryName);
                _data.Add(-item.Amount);
            }

            _chartData = new()
            {
                Labels = _lables,
                Datasets = new()
                {
                    new DataSet
                    {
                        Label = "",
                        Data = _data,
                        BackgroundColor = new() { "orange" },
                        BorderColor = new() { "orange" },
                        BorderWidth = 1
                    }
                }
            };
        }
        private void Add_RemoveSelectedCategory(CategoryDBModel item)
        {
            CategoryDBModel value = _model.Params.SelectedCategory.FirstOrDefault(i => i.Id == item.Id);

            if (value is not null)
            {
                _model.Params.SelectedCategory.Remove(value);
            }
            else
            {
                _model.Params.SelectedCategory.Add(item);
            }
        }
        private void Add_RemoveSelectedAccount(AccountDBModel item)
        {
            AccountDBModel value = _model.Params.SelectedAccounts.FirstOrDefault(i => i.Id == item.Id);

            if (value is not null)
            {
                _model.Params.SelectedAccounts.Remove(value);
            }
            else
            {
                _model.Params.SelectedAccounts.Add(item);
            }
        }
    }
}
