using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.Win32;



namespace MunicipalityManagement
{

    public partial class MainWindow : Window
    {
        string filePath = "";
        OpenFileDialog ofd = new OpenFileDialog();
        List<String> finalInfo = new List<string>();
        DataTable data = new DataTable();
        string separator = ",";
        string[] Header;

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
                //MessageBox.Show(filePath);
                ReadCsv();
            }
            
        }

        private void ReadCsv()
        {
            var Reader = new StreamReader(File.OpenRead(filePath));
            
            Header = Reader.ReadLine().Split(separator);
            while (Reader.ReadLine != null)
            {
                String temp = Reader.ReadLine();
                finalInfo.Add(temp);
            }
            CreateTable();
        }

        private void CreateTable() {
            for (int i = 0; i < Header.Length; i++)
            {
                data.Columns.Add(Header[i], typeof(String));
            }
            for(int i = 0; i < finalInfo.Count; i++)
            {
                string[] temp = finalInfo[i].Split(separator);
                data.Rows.Add(temp[0],temp[1],temp[2],temp[3],temp[4]);
            }
        }


    }
}
