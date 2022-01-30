using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;



namespace MunicipalityManagement
{

    public partial class MainWindow : Window
    {
        string filePath = "";
        OpenFileDialog ofd = new OpenFileDialog();
        ObservableCollection<Department> finalInfo = new ObservableCollection<Department>();
        string separator = ",";
        List<string> departments = new List<string>();
        ObservableCollection<Department> partialInfo;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ReadCsv()
        {
            
            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            for (int i = 1; i < 1122; i++)
            {
                String[] aux = sr.ReadLine().Split(separator);
                Department temp = new Department(aux[0], aux[1], aux[2], aux[3], aux[4]);
                finalInfo.Add(temp);
            }
        }

    
        private void LoaderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() != null)
            {
                filePath = ofd.FileName;
            }
            ReadCsv();
            ListView.ItemsSource = finalInfo;
            countDepartments();
            CBStarted();
            ListView.Visibility = Visibility.Visible;
            ListView2.Visibility = Visibility.Hidden;
            Filter.Visibility = Visibility.Visible;
            Graphic.Visibility = Visibility.Visible;
            countAgain();
        }

        public void countDepartments() {
            string aux = finalInfo[0].departmentCode;
            departments.Add(finalInfo[0].departmentName);
            for (int i = 0; i < finalInfo.Count; i++) {
                if (!(aux.Equals(finalInfo[i].departmentCode)))
                {
                    departments.Add(finalInfo[i].departmentName);
                    aux = finalInfo[i].departmentCode;
                }
            }
        }

        private void CBStarted() { 
            for(int i = 0; i < departments.Count; i++)
            {
                CB.Items.Add(departments[i]);
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            partialInfo = new ObservableCollection<Department>();
            if (CB.Text != "") {
                ListView.Visibility = Visibility.Hidden;
                ListView2.Visibility = Visibility.Visible;
                for (int i = 0; i < finalInfo.Count; i++)
                {
                    if (CB.Text.Equals(finalInfo[i].departmentName))
                    {
                        partialInfo.Add(finalInfo[i]);
                    }
                }
            }
            ListView2.ItemsSource = partialInfo;
        }
        public void countAgain()
        {
            int a = 0;
            int b = 0;
            int c = 0;
            for (int i = 0; i < finalInfo.Count; i++)
            {
                if (finalInfo[i].type.Equals("Isla"))
                {
                    a++;
                }
                else if (finalInfo[i].type.Equals("Municipio"))
                {
                    b++;
                }
                else
                {
                    c++;
                }
            }
        }

        private void Graphic_Click(object sender, RoutedEventArgs e)
        {

            Page1 newPage=new Page1();
            this.Close();
            newPage.Show();
           
            
        }
    }
       
}
public partial class Department{
    public String departmentCode { get; set; }
    public String municipalityCode { get; set; }
    public String departmentName { get; set; }
    public String municipalityName { get; set; }
   public  String type { get; set; }
    public Department(String departmentCode,String municipalityCode,
        String departmentName,String municipalityName, String type) {
        this.departmentCode = departmentCode;
        this.type = type;
        this.departmentName = departmentName;
        this.municipalityName = municipalityName;
        this.municipalityCode = municipalityCode;
    }

    
}


