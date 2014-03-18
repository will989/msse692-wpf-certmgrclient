using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient.CertificateWarehousePages
{
    /// <summary>
    /// Interaction logic for CertificateReportPage.xaml
    /// </summary>
    public partial class CertificateWarehouseReportPage : Page
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CertificateWarehouseReportPage()
        {
            InitializeComponent();

        }
        

        private void ListCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateWarehouseService.CertificateWarehouseServiceClient
                 wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

            log.Debug("after wsref in CertificateWarehouseReportPage");

            int limit = -1;
            int skip = -1;

            //check that value is an integer: http://stackoverflow.com/questions/10401633/validating-a-textbox-field-for-only-numeric-input
            if (int.TryParse(Limit.Text, out limit))
            {
                limit = Convert.ToInt32(Limit.Text);
            }
            else 
                limit = 1000;

            if (int.TryParse(Skip.Text, out skip))
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
                log.Debug("before List<Certificate> certList = new List<Certificate>(wsref.GetCertificatesDetails(limit, skip));");
                List<Certificate> certList =
                    new List<Certificate>(wsref.GetCertificatesDetails(limit, skip));
                log.Debug("after List<Certificate> certList = new List<Certificate>(wsref.GetCertificatesDetails(limit, skip));");
                
                //should be greater than 0
                int size = certList.Count;
                System.Diagnostics.Debug.WriteLine("certList count = {0}", size);

                foreach (Certificate certificate in certList)
                {
                    System.Diagnostics.Debug.WriteLine("ObjectId = {0}", certificate.Id.ToString());
                    log.Debug("in foreach (Certificate certificate in certList");

                    
                }
                CertDataGrid.ItemsSource = certList;
            }
            catch (WebException webException)
            {
                if (webException.Status == WebExceptionStatus.ProtocolError)
                {
             log.Error("Caught WebException: {0}", webException);
                  
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

