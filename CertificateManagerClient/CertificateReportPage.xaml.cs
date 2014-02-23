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

namespace CertificateManagerClient
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CertificateReportPage : Page
    {
        public CertificateReportPage()
        {
            InitializeComponent();

        }
        

        private void ListCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateManagerService.CertificateManagerServiceClient
                 wsref = new CertificateManagerService.CertificateManagerServiceClient();
            string newStoreName = null;
            string serverName = null;
            StoreName storeName = new StoreName();
            if (Store.SelectedItem != null)
            {
                newStoreName = Store.SelectedItem.ToString();
                if (newStoreName.Contains("CA"))
                    {
                        storeName = StoreName.CertificateAuthority;
                        newStoreName = storeName.ToString();
                        if (newStoreName.Equals("CertificateAuthority"))
                        {
                            newStoreName = "CA";
                        }
                        System.Diagnostics.Debug.WriteLine("newStoreName = {0}", newStoreName);
                    }
              
            }
            else
            {
                newStoreName = "CA";
            }
            //hard-coded since Local User only works on the local machine
                var storeLocation = StoreLocation.LocalMachine;

            if (ServerName.Text != null)
            {
                serverName = ServerName.Text;
            }
            else
            {
                serverName = "7000Laptop";
            }

            System.Diagnostics.Debug.WriteLine("serverName = {0}", serverName);
            System.Diagnostics.Debug.WriteLine("newStoreName = {0}", newStoreName);
            System.Diagnostics.Debug.WriteLine("storeLocation = {0}", storeLocation.ToString());
                


                //DataGrid stuff based on this:  http://www.dotnetperls.com/datagrid
                //try to retrieve certificates from a remote CA

            try
            {
                List<X509Certificate2> certList =
                    new List<X509Certificate2>(wsref.ListCertificatesInStore(newStoreName, storeLocation));

                //should be greater than 0
                int size = certList.Count;
                System.Diagnostics.Debug.WriteLine("certList count = {0}", size);
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
            List<X509Certificate2> items = null;
            var grid = sender as DataGrid;
            if (grid != null) grid.ItemsSource = items;
        }
    }
    }

