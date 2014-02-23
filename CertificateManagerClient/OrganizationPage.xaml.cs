using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient
{
    /// <summary>
    /// Interaction logic for Organization.xaml
    /// </summary>
    public partial class OrganizationPage : Page
    {
        //private Organization _organization;
        public OrganizationPage()
  
        {
            InitializeComponent();
            //Create an instance of the Person object.
            var organization = new Organization();
            organization = new Organization() {Name = "<Enter organization name>", OrganizationCertificates = null}
            ;
            
            //Set the DataContext of the Window.
            this.DataContext = organization;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }
    }
}
