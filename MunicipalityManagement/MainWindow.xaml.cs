using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Win32;



namespace MunicipalityManagement
{

    public partial class MainWindow : Window
    {
        string filePath = "";
        OpenFileDialog ofd = new OpenFileDialog();
        //List<var> information = new List<var>;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            if (ofd.ShowDialog()!=null)
            {
                //Get the path of specified file
                filePath = ofd.FileName;
                //txtEditor.Text=filePath;
                MessageBox.Show(filePath);
            }
        }

        private void ReadCsv() {
            var Reader = new StreamReader(File.OpenRead(filePath));
            string separator = ",";
            string Header = ",";
            Header = Reader.ReadLine();
            
           
           




        }

      
    }
}
