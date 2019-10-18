using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for GridCard.xaml
    /// </summary>
    public partial class GridCard : UserControl
    {
        private string dsn;
        private int id;
        private DataTable dt;
        List<view_trn_station_report> view_station_reports;
        SMTAssemblyLineDataContext db;
        

        public GridCard(string _dsn, int _id, string _title)
        {
            InitializeComponent();
            labelID.Content = _id;
            id = _id;
            dsn = _dsn;
            db = new SMTAssemblyLineDataContext(dsn);
            
            reloadData(id);
        }

        public void reloadData(int _id)
        {

            dt = new DataTable();
            dt.Columns.Add("station", typeof(string));
            dt.Columns.Add("avg", typeof(int));
            dt.Columns.Add("min", typeof(int));
            dt.Columns.Add("max", typeof(int));

            dt.Clear();

            view_station_reports = new List<view_trn_station_report>();

            view_station_reports = (from t in db.view_trn_station_reports where t.station_id == id && t.time_stamp.Value.Date==DateTime.Now.Date select t).ToList();

            foreach (var item in view_station_reports)
            {
                DataRow dr = dt.NewRow();
                dr["station"] = item.station_name;
                dr["avg"] = item.avg;
                dr["min"] = item.min;
                dr["max"] = item.max;
                dt.Rows.Add(dr);
            }

            gridControl.ItemsSource = dt;


        }
    }
}
