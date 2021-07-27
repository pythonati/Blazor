using FirstBlazor.Models.DB;
using FirstBlazor.Models.DB.View;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.Features.Dashboard.Chart1
{
    public partial class Chart1Page
    {
        private void Initialized()
        {
            CreateChartData();
        }
        private IEnumerable<Chart1DBModel> GetData()
        {
            string accounts = "";
            string category = "";

            foreach (var item in _model.Params.SelectedAccounts)
            {
                accounts += "[" + item.Id + "]";
            }

            foreach (var item in _model.Params.SelectedCategory)
            {
                category += "[" + item.Id + "]";
            }

            var _params = new Dictionary<string, string>()
            {
                {"dateFrom", _model.Params.DateFrom.ToString("yyyy-MM-dd") },
                { "dateTo", _model.Params.DateTo.ToString("yyyy-MM-dd") },
                { "accountTypes", accounts},
                { "categoryTypes", category }
            };

            return rep_chart.Items(_params);
        }
        private void CreateChartData()
        {
            List<string> labels = new();
            List<double> data = new();

            List<Chart1DBModel> baseData = GetData()?.ToList() ?? new();

            foreach (var item in baseData)
            {
                labels.Add(item.CategoryName);
                data.Add(item.Amount);
            }

            _chartData = new()
            {
                Labels = labels,
                Datasets = new()
                {
                    new DataSet
                    {
                        Label = "",
                        Data = data,
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
