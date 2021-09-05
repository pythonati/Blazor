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
            authUser.Authorization(navManager);

            CreateChartData();
        }
        private IEnumerable<Chart2DBModel> GetData()
        {
            string accounts = "";
            string category = "";
            string labels = "";

            foreach (var item in _model.Params.SelectedAccounts)
            {
                accounts += "[" + item.Id + "]";
            }

            foreach (var item in _model.Params.SelectedCategory)
            {
                category += "[" + item.Id + "]";
            }

            foreach (var item in _model.Params.SelectedLabels)
            {
                labels += "[" + item.Id + "]";
            }

            var _params = new Dictionary<string, string>()
            {
                { "dateFrom", _model.Params.DateFrom.ToString("yyyy-MM-dd") },
                { "dateTo", _model.Params.DateTo.ToString("yyyy-MM-dd") },
                { "accountTypes", accounts},
                { "categoryTypes", category },
                { "labelTypes", labels}
            };

            return rep_chart.Items(_params);
        }
        private void CreateChartData()
        {
            HashSet<string> labels = new();
            HashSet<int> categoryId = new();

            Dictionary<int, DataLabel> dataLabels = new();

            List<Chart2DBModel> baseData = GetData()?.ToList() ?? new();

            foreach (var item in baseData)
            {
                labels.Add(item.CategoryName);

                categoryId.Add(item.CategoryId);
            }

            foreach (var item in baseData)
            {
                if (!dataLabels.ContainsKey(item.LabelId))
                {
                    DataLabel label = new()
                    {
                        Id = item.LabelId,
                        Name = item.LabelName,
                        Data = new()
                    };

                    foreach (var cid in categoryId)
                    {
                        label.Data.Add(cid, 0);
                    }

                    dataLabels.Add(item.LabelId, label);
                };

                dataLabels[item.LabelId].Data[item.CategoryId] = item.Amount;
            };

            _chartData = new()
            {
                Labels = labels.ToList(),
                Datasets = new()
            };

            foreach (var item in dataLabels)
            {
                DataSet dataset = new()
                {
                    Label = item.Value.Name,
                    Data = item.Value.Data.Values.ToList(),
                    BackgroundColor = new() { "orange" },
                    BorderColor = new() { "orange" },
                    BorderWidth = 1
                };

                _chartData.Datasets.Add(dataset);
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
        private void Add_RemoveSelectedLabel(LableDBModel item)
        {
            LableDBModel value = _model.Params.SelectedLabels.FirstOrDefault(i => i.Id == item.Id);

            if (value is not null)
            {
                _model.Params.SelectedLabels.Remove(value);
            }
            else
            {
                _model.Params.SelectedLabels.Add(item);
            }
        }

        private class DataLabel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Dictionary<int, double> Data { get; set; } = new();
        }
    }
}
