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

namespace ClassLibrary1.Interfaces
{
    /// <summary>
    /// Interaction logic for DialogNewStation.xaml
    /// </summary>
    public partial class DialogNewStation : UserControl
    {
        private bool result = false;

        public DialogNewStation()
        {
            InitializeComponent();
        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            result = true;
            PopupDialogFunctions.close_dialog();
        }

        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            result = false;
            PopupDialogFunctions.close_dialog();
        }

        public bool resultDialog
        {
            get { return result; }
        }

        public string stationName
        {
            get { return textEditTitle.Text; }
        }

    }
}
