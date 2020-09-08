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

namespace CompanyServiceClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetPublicInformation(object sender, RoutedEventArgs e)
        {
            CompanyServiceProxy.CompanyPublicServiceClient proxy = new CompanyServiceProxy.CompanyPublicServiceClient("BasicHttpBinding_ICompanyPublicService");
            lblPublicInformation.Content = proxy.GetPublicInformation();
        }

        private void GetConfidentialInformation(object sender, RoutedEventArgs e)
        {
            CompanyServiceProxy.CompanyConfidentialServiceClient proxy = new CompanyServiceProxy.CompanyConfidentialServiceClient("NetTcpBinding_ICompanyConfidentialService");
            lblConfidentialInformation.Content = proxy.GetConfidentialInformation();
        }
    }
    
}
