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
using GlobalArcOpsFunctionality;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Class;
using System.Configuration;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dsn;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        public UEIOSEntities class_ueios_entity;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ReadINI readINI = new ReadINI("Config.ini");
            dsn = readINI.GetDNS();


            //var appSettings = ConfigurationSettings.AppSettings;
            //string connection_string = appSettings["connectionString"];
            //string internal_connection_string = appSettings["internalConnectionString"];

            //DatabaseFunctions.set_ueios_connection_string(connection_string);
            //DatabaseFunctions.set_internal_connection_string(internal_connection_string);

            //DatabaseFunctions.create_and_set_global_ueios_entity();
            //DatabaseFunctions.create_new_ueios_entity();
            //class_ueios_entity = DatabaseFunctions.get_global_ueios_entity();

            SMTAssemblyLine sMTAssemblyLine_userControl = new SMTAssemblyLine(dsn);

            mainWindow.Content = sMTAssemblyLine_userControl;
        }


        
    }
}
