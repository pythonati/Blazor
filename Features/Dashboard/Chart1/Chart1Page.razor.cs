using FirstBlazor.Models.DB.View;
using System.Collections.Generic;

namespace FirstBlazor.Features.Dashboard.Chart1
{
    public partial class Chart1Page
    {
        private void Initialized()
        {
            CreateChartData();
        }
        private IEnumerable<Chart1DBModel> getData()
        {
            var _params = new Dictionary<string, string>(4);

            _params.Add("dateFrom", "2021-07-01");
            _params.Add("dateTo", "2022-07-01");
            _params.Add("accountTypes", null);
            _params.Add("categoryTypes", null);

            return rep_chart.Items(_params);
        }
        private void CreateChartData()
        {
            List<string> _lables = new();
            List<double> _data = new();

            foreach(var item in getData())
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
    }
}
