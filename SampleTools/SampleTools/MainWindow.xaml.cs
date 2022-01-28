using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Configuration;
using System.IO;

namespace SampleTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CultureInfo culture = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);            

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        private void btnTransform_Click(object sender, RoutedEventArgs e)
        {
            string logInputFolderPath = ConfigurationManager.AppSettings["TransformInputPath"] ;
            string logOutFolderPath = ConfigurationManager.AppSettings["TransformOutputPath"] +"/" ;// + "/" + DateTime.Now.ToString("yyyy-MM-dd");
            int indexVal = Convert.ToInt32(ConfigurationManager.AppSettings["TransformFileIndex"]);



            if (!String.IsNullOrEmpty(logInputFolderPath) && !String.IsNullOrEmpty(logOutFolderPath))
            {
                string[] fileEntries = Directory.GetFiles(logInputFolderPath);
                foreach (string file in fileEntries)
                {
                    var newFileName = file.Replace(logInputFolderPath + "\\" , "").Substring(indexVal);
                    FileInfo fileInfo = new FileInfo(file);
                    fileInfo.MoveTo(logOutFolderPath + newFileName);
                  

                }
                MessageBox.Show("Done!!");
            }
            else
                MessageBox.Show("Configuration missing!!");

        }
    }
}
