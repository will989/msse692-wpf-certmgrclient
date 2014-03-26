using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient.CertificateManagerPages
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CertificateManagerDeleteCertificatePage : Page
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CertificateManagerDeleteCertificatePage()
        {
            InitializeComponent();
            log.Debug("In CertificateManager DeleteCertificate Page InitializeComponent");
        }


        private void DeleteCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            //CertificateWarehouseService.CertificateWarehouseServiceClient
            //     wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

            //instantiate windows service
            //CalculatorService.CalculatorClient wsref = new CalculatorService.CalculatorClient();
            CertificateService.CertificateClient wsref = new CertificateService.CertificateClient();
            DeleteLabel.Content = "";


            string thumbprint = null;
            string certName = null;

            bool removed = false;
            string newStoreName = null;
            string serverName = ServerName.Text;

            if (Store.SelectedItem != null)
            {
                int index = Store.SelectedIndex;
                switch (index)
                {
                    case 0:
                    {
                        newStoreName = "CA";
                        break;
                    }
                    case 1:
                    {
                        newStoreName = "My";
                        break;
                    }
                    case 2:
                    {
                        newStoreName = "Root";
                        break;
                    }
                    case 3:
                    {
                        newStoreName = "AuthRoot";
                        break;
                    }
                    default:
                    {
                        newStoreName = "CA";
                        break;
                    }
                }
            } //end if

                //else just make the default "CA"
            else
            {
                newStoreName = "CA";
            }

            thumbprint = Thumbprint.Text;
            certName = CertName.Text;

            try
            {
                if (thumbprint.Length >= 1)
                {
                    log.Debug("In Thumbprint.Text.Length...calling ");
                    removed = wsref.DeleteCertificateByThumbprintRemote(thumbprint, newStoreName,
                        StoreLocation.LocalMachine, serverName);
                }
                else if (certName.Length >= 1)
                {
                    log.Debug("In CertName.Text.Length...calling ");
                    removed = wsref.DeleteCertificateRemote(certName, newStoreName, StoreLocation.LocalMachine,
                        serverName);
                }

                if (removed)
                {
                    log.Debug("Removed is true - certificate was removed!");
                    DeleteLabel.Content = "Certificate was removed!";
                    MessageBox.Show("Certificate was removed!");
                }
                else
                {
                    log.Debug("Removed is false - certificate was not removed...");
                    DeleteLabel.Content = "Unable to remove certificate.";
                    MessageBox.Show("Unable to remove certificate.");
                }
            }
            catch (EndpointNotFoundException epnfe)
            {
                System.Diagnostics.Debug.WriteLine("EndpointNotFoundException caught: {0}", epnfe);
                log.Error("Caught EndpointNotFoundException: {0}", epnfe);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception caught: {0}", ex);
                log.Error("Caught Exception: {0}", ex);
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