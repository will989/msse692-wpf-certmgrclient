using System;
using System.Windows;
using System.Windows.Controls;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient.OrganizationPages
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
