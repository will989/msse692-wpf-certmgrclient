using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient.CertificateWarehousePages
    
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CertificateWarehouseDeleteCertificatePage : Page
    {
        public CertificateWarehouseDeleteCertificatePage()
        {
            InitializeComponent();

        }
        

        private void DeleteCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateWarehouseService.CertificateWarehouseServiceClient
                 wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

            Certificate MyCertificate = new Certificate();
            string thumbprint = null;
            string id = null;
            string name = null;
            bool removed = false;
            try
            {
                if (Thumbprint.Text.Length >= 1)
                {
                    removed = wsref.RemoveCertificateFromDatabase(Thumbprint.Text);
                }
                
                
                System.Diagnostics.Debug.WriteLine("Thumbprint = {0}", MyCertificate.Thumbprint);
                
                //from here:  http://www.codeproject.com/Articles/321899/DataContext-in-WPF
                if (removed)
                {
                    DeleteLabel.Content = "Certificate Deleted!";
                }
                else
                {
                    DeleteLabel.Content = "Unable to Delete Certificate";
                }
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

