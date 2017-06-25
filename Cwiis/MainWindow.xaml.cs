using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Cwiis
{
   
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            J03.SetFile(@"Resource\J03.txt");
            J04.SetFile(@"Resource\J04.txt");
            J05.SetFile(@"Resource\J05.txt");
            J06.SetFile(@"Resource\J06.txt");
            //J07.SetFile(@"Resource\J07.txt");
            J08.SetFile(@"Resource\J08.txt");
            J09.SetFile(@"Resource\J09.txt");
           // J10.SetFile(@"Resource\J10.txt");
        }
    }
}
