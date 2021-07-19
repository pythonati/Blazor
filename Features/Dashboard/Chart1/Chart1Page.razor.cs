using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Features.Dashboard.Chart1
{
    public partial class Chart1Page
    {
        private void Initialized()
        {
            CreateChartData();
        }
        private void CreateChartData()
        {
            _chartData = new()
            {
                Labels = new() { "Completed Repairs", "Outstanding Repairs" },
                Datasets = new()
                {
                    new DataSet
                    {
                        Label = "Completed Repairs",
                        Data = new() { 10, 20 },
                        BackgroundColor = new() { "rgba(63, 191, 63, 0.5)", "rgba(54, 162, 235, 0.2)" },
                        BorderColor = new() { "rgba(51, 153, 51, 0.70)", "rgba(54, 162, 235, 1)" }
                    }
                }
            };
        }
    }
}
