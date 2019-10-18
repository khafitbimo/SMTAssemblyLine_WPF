using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassLibrary1.Interfaces
{
    /// <summary>
    /// Interaction logic for ChartControl.xaml
    /// </summary>
    public partial class ChartControl : UserControl
    {
        private string dsn;
        SMTAssemblyLineDataContext db;

       

        public ChartControl(string _dsn)
        {
            InitializeComponent();
            this.dsn = _dsn;
            db = new SMTAssemblyLineDataContext(dsn);

            diagramLine.ActualAxisX.Title = new AxisTitle() { Content = "Hour" };
            diagramLine.ActualAxisY.Title = new AxisTitle() { Content = "Count" };
            LoadChart();
        }

        public void LoadChart()
        {
           
            diagramLine.Series.Clear();

            List<master_station> master_stations = (from t in db.master_stations select t).ToList();

            foreach (var item in master_stations)
            {
                LineSeries2D series = new LineSeries2D();
                series.Points.Clear();
                series.DisplayName = item.station_name;
                series.Name = item.station_name;
                diagramLine.Series.Add(series);

                List<view_trn_station_inhour> view_Trn_Station_Inhours = (from a in db.view_trn_station_inhours where a.station_id == item.id && a.TimeStampHour.Value.Date == DateTime.Now.Date select a).ToList();

                foreach (var count in view_Trn_Station_Inhours)
                {
                    series.Points.Add(new SeriesPoint(Convert.ToString(count.in_hours), Convert.ToDouble(count.count)));

                }
            }

           
        }

        
    }
}
