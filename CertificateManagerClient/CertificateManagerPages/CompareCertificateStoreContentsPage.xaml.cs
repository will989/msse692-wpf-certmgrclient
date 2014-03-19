using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CertificateManagerClient.CertificateManagerPages
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CompareCertificateStoreContentsPage : Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CompareCertificateStoreContentsPage()
        {
            InitializeComponent();
            log.Debug("In CompareCertificateStore... InitializeComponent");

        }
        

        private void ListCertButton_Click(object sender, RoutedEventArgs e)
        {
            //(Replaced by Windows service...) instantiate web service
            //CertificateManagerService.CertificateManagerServiceClient
            //     wsref = new CertificateManagerService.CertificateManagerServiceClient();

            //instantiate windows service client
            //CalculatorService.CalculatorClient wsref = new CalculatorService.CalculatorClient();
            CertificateService.CertificateClient wsref = new CertificateService.CertificateClient();
            CertificateService.CertificateClient wsref2 = new CertificateService.CertificateClient();
            CertificateService.CertificateClient wsref3 = new CertificateService.CertificateClient();

            string newStoreName = null;
            string serverName = null;
            string serverName2 = null;
            StoreName storeName = new StoreName();
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
                serverName = ServerName2.Text;
            }
            else
            {
                serverName = "7000Laptop";
            }

            if (ServerName2.Text.Length < 3 || ServerName2.Text.Equals(""))
            {
                serverName2 = ServerName2.Text;
            }
            else
            {
                serverName2 = "7000Laptop";
            }

            System.Diagnostics.Debug.WriteLine("serverName = {0}", serverName);
            System.Diagnostics.Debug.WriteLine("serverName2 = {0}", serverName2);
            System.Diagnostics.Debug.WriteLine("newStoreName = {0}", newStoreName);
            System.Diagnostics.Debug.WriteLine("storeLocation = {0}", storeLocation.ToString());
                
            //first, list the contents for the 2 servers:
            try
            {
                log.Debug("Right before first ListCertificatesInRemoteStore -- server1");
                wsref.InnerChannel.OperationTimeout = new TimeSpan(0, 2, 0);
                wsref.Open();
                var serverCertList =
                    new List<X509Certificate2>(wsref.ListCertificatesInRemoteStore(newStoreName, storeLocation,
                        serverName));
                log.Debug("Right after first ListCertificatesInRemoteStore -- server1");
                //should be greater than 0
                int size = serverCertList.Count;
                System.Diagnostics.Debug.WriteLine("certList count = {0}", size);
                Server1Label.Content = serverName;
                Server1CertDataGrid.ItemsSource = serverCertList;
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
            finally
            {
                wsref.Close();
            }



            try
            {
                

                //http://stackoverflow.com/questions/16716247/wcf-service-timeout-setting
                //try setting timeout to 2 minutes
                wsref2.InnerChannel.OperationTimeout = new TimeSpan(0, 2, 0);
                wsref2.Open();
                log.Debug("Right before second ListCertificatesInRemoteStore -- server2");
                var server2CertList = new List<X509Certificate2>(wsref2.ListCertificatesInRemoteStore(newStoreName, storeLocation, serverName2));
                log.Debug("Right after second ListCertificatesInRemoteStore -- server2");

                //should be greater than 0
                int size = server2CertList.Count;
                System.Diagnostics.Debug.WriteLine("certList count = {0}", size);
                Server2Label2.Content = serverName2;
                Server2CertDataGrid.ItemsSource = server2CertList;
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
            {
                wsref2.Close();
            }


            //DataGrid stuff based on this:  http://www.dotnetperls.com/datagrid
                //try to retrieve certificates from a remote CA

            try
            {
                log.Debug("right before CompareCertificatesInStore call");
                wsref3.InnerChannel.OperationTimeout = new TimeSpan(0, 2, 0);
                wsref3.Open();
                List<X509Certificate2> certList =
                    new List<X509Certificate2>(wsref3.CompareCertificatesInStore(newStoreName, storeLocation, serverName,
                        serverName2));
                log.Debug("right after CompareCertificatesInStore call");
                //should be greater than 0
                int size = certList.Count;
                System.Diagnostics.Debug.WriteLine("certList count = {0}", size);
                CertDataGrid.ItemsSource = certList;
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
            finally
            {
                wsref3.Close();
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

