using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    /// Interaction logic for StationCard.xaml
    /// </summary>
    public partial class StationCard : UserControl
    {

        private string dsn;
        SMTAssemblyLineDataContext db;
        private int count_data;
        private int id;

        public ChartControl chartUserControl { get; set; }

        public GridCard gridCard { get; set; }

        public StationCard(string _dsn, int _id,string _title)
        {
            InitializeComponent();
            labelID.Content = _id;
            dsn = _dsn;

            id = _id;
            db = new SMTAssemblyLineDataContext(dsn);

            count_data = (from t in db.trn_stations where t.station_id == id && t.time_stamp.Value.Date == DateTime.Now.Date  select t).Count();

            labelCount.Content = count_data;
            labelName.Content = _title;

        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
           
            if (addStationCount())
            {
                gridCard.reloadData(id);
                chartUserControl.LoadChart();
            }
        }

        private bool addStationCount()
        {
            try
            {
                count_data = db.sp_trn_station_insert(id);
                labelCount.Content = count_data;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }
    }
}
