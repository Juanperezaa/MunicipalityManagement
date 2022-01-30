using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
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

       /* private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() != null)
            {
                //Get the path of specified file
                filePath = ofd.FileName;
                //txtEditor.Text=filePath;
                //MessageBox.Show(filePath);
                //ReadCsv();
            }
           // dataGridTable.DataContext = data;
        }*/

        private IEnumerable<Department> ReadCsv(String filePath)
        {

            String[] reading = File.ReadAllLines(filePath);
            return reading.Select(line =>
            {
                string[] data = line.Split(",");
                return new Department(data[0], data[1], (data[2]), data[3], data[4]);
            });
           // CreateTable();
        }

        private void CreateTable() {
            for (int i = 0; i < Header.Length; i++)
            {
                data.Columns.Add(Header[i], typeof(String));
            }
            for (int i = 0; i < finalInfo.Count; i++)
            {
                string[] temp = finalInfo[i].Split(separator);
                data.Rows.Add(temp[0], temp[1], temp[2], temp[3], temp[4]);
            }
        }


        private void LoaderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() != null)
            {
                filePath = ofd.FileName;
            }
            ListView.ItemsSource = ReadCsv(filePath);
        }
    }

       
}
public partial class Department{
    public String departmentCode { get; set; }
    public String municipalityCode { get; set; }
    public String departmentName { get; set; }
    public String MunicipalityName { get; set; }
   public  String type { get; set; }
    public Department(String departmentCode,String municipalityCode,
        String departmentName,String municipalityName, String type) {
        this.departmentCode = departmentCode;
        this.type = type;
        this.departmentName = departmentName;
        this.MunicipalityName = municipalityName;
        this.municipalityCode = municipalityCode;
    }

    
}


