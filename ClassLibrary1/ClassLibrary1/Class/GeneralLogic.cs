using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClassLibrary1.Class
{
    public class GeneralLogic
    {
        public delegate void openUserControl(UserControl userControl);
        public openUserControl openUserControlDelegate = null;

        
    }
}
