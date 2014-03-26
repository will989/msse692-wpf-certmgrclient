using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient.CertificateWarehousePages
{
    /// <summary>
    /// Interaction logic for CertificateWarehouseExpiringCertificateReportPage.xaml
    /// </summary>
    public partial class CertificateWarehouseExpiringCertificateReportPage : Page
    {
        public CertificateWarehouseExpiringCertificateReportPage()
        {
            InitializeComponent();
        }


        private void ListCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateWarehouseService.CertificateWarehouseServiceClient
                wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

            int expirationDays = Convert.ToInt32(ExpCertDays.Text);


            System.Diagnostics.Debug.WriteLine("# of days = {0}", expirationDays);


            //DataGrid stuff based on this:  http://www.dotnetperls.com/datagrid
            //try to retrieve certificates from a remote CA

            try
            {
                List<Certificate> expCertList =
                    new List<Certificate>(wsref.GetCertificatesByExpirationDate(expirationDays));

                //should be greater than 0
                int size = expCertList.Count;
                System.Diagnostics.Debug.WriteLine("expCertList count = {0}", size);
                CertDataGrid.ItemsSource = expCertList;
            }
            catch (EndpointNotFoundException epnfe)
            {
                System.Diagnostics.Debug.WriteLine("EndpointNotFoundException caught: {0}", epnfe);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception caught: {0}", ex);
            }
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<X509Certificate2> items = null;
            var grid = sender as DataGrid;
            if (grid != null) grid.ItemsSource = items;
        }
    }
}