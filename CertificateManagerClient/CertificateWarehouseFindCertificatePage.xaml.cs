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
using MongoDB.Bson;
using MongoDB.Driver;
using ObjectId = MongoDB.Bson.ObjectId;

namespace CertificateManagerClient
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CertificateWarehouseFindCertificatePage : Page
    {
        public CertificateWarehouseFindCertificatePage()
        {
            InitializeComponent();

        }
        

        private void FindCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateWarehouseService.CertificateWarehouseServiceClient
                 wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

            Certificate MyCertificate = new Certificate();
            string thumbprint = null;
            string id = null;
            string name = null;
            try
            {
                if (Thumbprint.Text.Length >= 1)
                {
                    MyCertificate = wsref.GetCertificateByThumbprint(Thumbprint.Text);
                }
                else if (MongoId.Text.Length >= 1)
                {
                    MyCertificate = wsref.GetCertificateById(MongoId.Text);
                }
                else if (CertName.Text.Length >= 1)
                {
                    MyCertificate = wsref.GetCertificateByName(CertName.Text);
                }

                System.Diagnostics.Debug.WriteLine("Name = {0}", MyCertificate.Name);
                System.Diagnostics.Debug.WriteLine("Thumbprint = {0}", MyCertificate.Thumbprint);
                System.Diagnostics.Debug.WriteLine("StartDate = {0}", MyCertificate.StartDate);
                System.Diagnostics.Debug.WriteLine("ExpirationDate = {0}", MyCertificate.ExpirationDate);

                //from here:  http://www.codeproject.com/Articles/321899/DataContext-in-WPF
                if (MyCertificate != null) this.DataContext = MyCertificate;
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

