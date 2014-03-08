using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace CertificateManagerClient.CertificateManagerPages
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class ExpiringCertificateReportPage : Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ExpiringCertificateReportPage()
        {
            InitializeComponent();
            log.Debug("In ExpiringCertificateReportPage InitializeComponent");

        }
        

        private void ListCertButton_Click(object sender, RoutedEventArgs e)
        {
            //(Replaced by Windows service...) instantiate web service
            //CertificateManagerService.CertificateManagerServiceClient
            //     wsref = new CertificateManagerService.CertificateManagerServiceClient();

            //instantiate windows service client
            CalculatorService.CalculatorClient wsref = new CalculatorService.CalculatorClient();

            string newStoreName = null;
            string serverName = null;
            StoreName storeName = new StoreName();
            int expirationDays = Convert.ToInt32(ExpCertDays.Text);
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
            }//end if

            //hard-coded since Local User only works on the local machine
                var storeLocation = StoreLocation.LocalMachine;

                if (ServerName.Text.Length > 3 && !ServerName.Text.Equals(""))
            {
                serverName = ServerName.Text;
                try
                {
                    List<X509Certificate2> expCertList =
                        new List<X509Certificate2>(wsref.ListExpiringCertificatesInRemoteStore(newStoreName,
                            storeLocation, expirationDays, serverName));


                    //should be greater than 0
                    int size = expCertList.Count;
                    System.Diagnostics.Debug.WriteLine("expCertList count = {0}", size);
                    CertDataGrid.ItemsSource = expCertList;
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
            else
            {
                System.Diagnostics.Debug.WriteLine("serverName is null!!");
                try
                {
                    List<X509Certificate2> expCertList =
                        new List<X509Certificate2>(wsref.ListExpiringCertificatesInStore(newStoreName, storeLocation, expirationDays));

                    //should be greater than 0
                    int size = expCertList.Count;
                    System.Diagnostics.Debug.WriteLine("expCertList count = {0}", size);
                    CertDataGrid.ItemsSource = expCertList;
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

            
           
            System.Diagnostics.Debug.WriteLine("serverName = {0}", serverName);
            System.Diagnostics.Debug.WriteLine("newStoreName = {0}", newStoreName);
            System.Diagnostics.Debug.WriteLine("storeLocation = {0}", storeLocation.ToString());
            System.Diagnostics.Debug.WriteLine("# of days = {0}", expirationDays);
                


                //DataGrid stuff based on this:  http://www.dotnetperls.com/datagrid
                //try to retrieve certificates from a remote CA

            
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<X509Certificate2> items = null;
            var grid = sender as DataGrid;
            if (grid != null) grid.ItemsSource = items;
        }
    }
    }

