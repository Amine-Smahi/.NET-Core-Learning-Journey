using System.Collections.Generic;

namespace NetCoreCharts.Models {
    public class StackedViewModel {
        public string StackedDimensionOne { get; set; }
        public List<SimpleReportViewModel> LstData { get; set; }
    }
}