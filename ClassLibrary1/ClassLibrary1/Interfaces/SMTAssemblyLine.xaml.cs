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
using ClassLibrary1.Class;
using ClassLibrary1.Interfaces;
using DevExpress.Xpf.Charts;
using GlobalArcOpsFunctionality;


namespace ClassLibrary1.Interfaces
{
    /// <summary>
    /// Interaction logic for SMTAssemblyLine.xaml
    /// </summary>
    public partial class SMTAssemblyLine : UserControl
    {
        private string dsn;
        SMTAssemblyLineDataContext db;
        XYDiagram2D diagram = new XYDiagram2D();

        ChartControl chartUserControl;

        public SMTAssemblyLine(string _dsn)
        {
            InitializeComponent();
            this.dsn = _dsn;
            db = new SMTAssemblyLineDataContext(dsn);
            chartUserControl = new ChartControl(dsn);

            

            List < master_station > masterStations = (from t in db.master_stations select t).ToList();

            foreach (var masterStation in masterStations)
            {
                addNewStation(masterStation.id, masterStation.station_name, chartUserControl);
            }


            this.layoutItemChart.Content = chartUserControl;
           
        }

       

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            string station_name = "";
            int id=0;
            DialogNewStation dialogNewStation = new DialogNewStation();

            PopupDialogFunctions.open_dialog(150, 500, dialogNewStation);

            if (dialogNewStation.resultDialog)
            {
                station_name = dialogNewStation.stationName;

                if (addNewStationToDB(ref id,station_name))
                {
                    addNewStation(id, station_name, chartUserControl);
                }
            }
            
            //addNewStation(0, "");
        }

        private bool addNewStationToDB(ref int _id, string _station_name)
        {
            try
            {
                master_station mstStation = new master_station();
                mstStation.station_name = _station_name;

                db.master_stations.InsertOnSubmit(mstStation);
                db.SubmitChanges();
                _id = mstStation.id;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        private void addNewStation(int _id, string _title, ChartControl _chartUserControl)
        {
            
            GridCard gridCard = new GridCard(dsn,_id, _title);
            StationCard stationCard = new StationCard(dsn, _id, _title);
            stationCard.gridCard = gridCard;
            stationCard.chartUserControl = _chartUserControl;

            stationCard.Width = 400;
            flowLayoutStation.Children.Add(stationCard);

            gridCard.Width = 400;
            gridCard.Height = 200;
            flowLayoutGrid.Children.Add(gridCard);

        }
    }
}
