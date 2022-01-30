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

namespace MunicipalityManagement
{
   
    public partial class Page1 : Window
    {
        public Page1()
        {
            InitializeComponent();
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newPage = new MainWindow();
            this.Close();
            newPage.Show();
        }

        private void Pane_Initialized(object sender, EventArgs e)
        {
            IslandRec.Width = 30;
            IslandRec.Height = 38;
            MunicipalityRec.Width = 383;
            MunicipalityRec.Height = 38;
            NoMRec.Width = 162;
            NoMRec.Height = 38;
        }
    }
}
