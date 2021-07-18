using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Features.Dashboard
{
    public class ChartData
    {
        public List<string> Labels { get; set; } = new();
        public List<DataSet> Datasets { get; set; } = new();
    }

    public class DataSet
    {
        public string Label { get; set; }
        public List<int> Data { get; set; } = new();
        public List<string> BackgroundColor { get; set; } = new();
        public List<string> BorderColor { get; set; } = new();
        public int BorderWidth { get; set; }
    }
}
