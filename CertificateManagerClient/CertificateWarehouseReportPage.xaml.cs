using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CertificateWarehouseReportPage : Page
    {
        public CertificateWarehouseReportPage()
        {
            InitializeComponent();

        }
        

        private void ListCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateWarehouseService.CertificateWarehouseServiceClient
                 wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

            int limit = -1;
            int skip = -1;

            if (Limit.Text.Length >= 1)
            {
                limit = Convert.ToInt32(Limit.Text);
            }
            else 
                limit = 1000;

            if (Skip.Text.Length >= 1)
            {
                skip = Convert.ToInt32(Skip.Text);
            }
            else
                skip = 0;

            //need to validate fields to make sure that they are integers
            if (limit < 0)
            {
                limit = 1000;
            }


            if (skip < 0)
            {
                skip = 0;
            }


            System.Diagnostics.Debug.WriteLine("Limit = {0}", limit);
            System.Diagnostics.Debug.WriteLine("Skip = {0}", skip);

            //DataGrid stuff based on this:  http://www.dotnetperls.com/datagrid
                //try to retrieve certificates from a remote CA

            try
            {
                List<Certificate> certList =
                    new List<Certificate>(wsref.GetCertificatesDetails(limit, skip));

                //should be greater than 0
                int size = certList.Count;
                System.Diagnostics.Debug.WriteLine("certList count = {0}", size);

                foreach (Certificate certificate in certList)
                {
                    System.Diagnostics.Debug.WriteLine("ObjectId = {0}", certificate.Id.ToString());
                }
                CertDataGrid.ItemsSource = certList;
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
            List<Certificate> items = null;
            var grid = sender as DataGrid;
            if (grid != null) grid.ItemsSource = items;
        }
    }
    }

