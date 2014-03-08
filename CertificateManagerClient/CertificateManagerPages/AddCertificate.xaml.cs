using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using CertificateManagerClient.CertificateManagerService;
using CertificateManagerClient.CertificateWarehouseService;


namespace CertificateManagerClient.CertificateManagerPages
{
    /// <summary>
    /// Interaction logic for AddCertificate.xaml
    /// </summary>
    
    public partial class AddCertificate : Page
    {
        //Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private X509Certificate2 _loadedCertificate = new X509Certificate2();

        public AddCertificate()
        {
            InitializeComponent();
            log.Debug("In AddCertificate");
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.CertChooser.Text = ofd.FileName;
            }

            try

            {
                //load certificate from selected file
                _loadedCertificate = new X509Certificate2(ofd.FileName);
                System.Diagnostics.Debug.WriteLine("Reading Client Certificate Information");
                //null check to make sure certificate was loaded, then populate form
                if (_loadedCertificate.SubjectName.Name != null) CertName.Text = _loadedCertificate.SubjectName.Name;
                else
                {
                    System.Diagnostics.Debug.WriteLine("Certificate Name was null, certificate not loaded correctly");
                }
                StartDate.Text = _loadedCertificate.NotBefore.ToLongDateString();
                EndDate.Text = _loadedCertificate.NotAfter.ToLongDateString();
                ExpirationDate.Text = _loadedCertificate.NotAfter.ToLongDateString();
                Thumbprint.Text = _loadedCertificate.Thumbprint;
                //try storing content this way (http://www.dotnetperls.com/convert-string-byte-array)
                CertContent.Text = Encoding.ASCII.GetString(_loadedCertificate.RawData);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void AddCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            //CertificateManagerService.CertificateManagerServiceClient
            //     wsref = new CertificateManagerService.CertificateManagerServiceClient();


            //instantiate windows service
            CalculatorService.CalculatorClient wsref = new CalculatorService.CalculatorClient();

            //instantiate windows service  -- this gives "The type name 'CertManagerSvc' does not exist in the type... error
            //CertManagerSvc.CertificateManagerClient wsref = new CertManagerSvc.CertificateManagerClient();

            string serverName = null;

            X509Certificate2 certificate2 = new X509Certificate2();
            string newStoreName = null;
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

            //else just make the default "CA"
            else
            {
                newStoreName = "CA";
            }

            
            StoreLocation storeLocation = StoreLocation.LocalMachine;
 

            bool added = false;
            if (ServerName.Text.Length > 3 && !ServerName.Text.Equals(""))
            {
                serverName = ServerName.Text;
                try
                {
                    //pass in the loadedCertificate
                    log.Debug("just before added");
                    added = wsref.InstallCertificateRemote(newStoreName, storeLocation, _loadedCertificate, serverName);
                    log.Debug("just after added");
                }
                catch (EndpointNotFoundException epnfe)
                {
                    System.Diagnostics.Debug.WriteLine("EndpointNotFoundException caught: {0}", epnfe);
                    log.Error("Caught EndpointNotFoundException: {0}", epnfe);
                }
                catch (Exception ex)
                {
                    log.Error("Caught Exception: {0}", ex);
                    System.Diagnostics.Debug.WriteLine("Exception caught: {0}", ex);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("serverName is null!!");
                try
                {
                    //pass in the loadedCertificate
                    log.Debug("just before added");
                    added = wsref.InstallCertificateLocal(newStoreName, storeLocation, _loadedCertificate);
                    log.Debug("just after added");
                }
                catch (EndpointNotFoundException epnfe)
                {
                    log.Error("Caught EndpointNotFoundException: {0}", epnfe);
                    System.Diagnostics.Debug.WriteLine("EndpointNotFoundException caught: {0}", epnfe);
                }
                catch (Exception ex)
                {
                    log.Error("Caught Exception: {0}", ex);
                    System.Diagnostics.Debug.WriteLine("Exception caught: {0}", ex);
                }
            }

            if (added)
            {
                System.Diagnostics.Debug.WriteLine("Certificate was added");
                log.Debug("Added is True, certificate was added!");
            }
            else
            {
                {
                    log.Debug("Added is false");
                }
            }
        }

        //did not end up using this
        public void OnExecute(object parameter)
        {
            var values = (object[])parameter;
            var fileName = (string)values[0];
            var serverName = (string)values[1];
            var myStoreName = (string) values[2];
        }
        
                private void SaveCertButton_Click(object sender, RoutedEventArgs e)
                {
             //instantiate web service
              //      CertificateWarehouseService.CertificateWarehouseServiceClient
                //        wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();

                    //instantiate windows service
                    CalculatorService.CalculatorClient wsref = new CalculatorService.CalculatorClient();
                    //CertManagerSvc.CertificateManagerClient wsref = new CertManagerSvc.CertificateManagerClient();

            
                    //new CertificateManager Certificate
                    Certificate certificate = new Certificate();
                    //certificate.Name = CertName.Text;
                    //certificate.StartDate = Convert.ToDateTime(StartDate.Text);
                    //certificate.EndDate = Convert.ToDateTime(EndDate.Text);
                    //certificate.ExpirationDate = Convert.ToDateTime(ExpirationDate.Text);
                    //certificate.Thumbprint = Thumbprint.Text;
                    //try converting certificate content from text back to bytes (http://www.dotnetperls.com/convert-string-byte-array)
                    certificate.Content = Encoding.ASCII.GetBytes(CertContent.Text);

                    //hard-coding because I'm not using this database stuff on this page
                    bool added = true; //wsref.AddCertificateToDatabase(certificate);

                    if (added)
                    {
                        System.Diagnostics.Debug.WriteLine("Certificate added!");
                        //System.Diagnostics.Debug.WriteLine("Certificate Thumbprint = {0}", certificate.Thumbprint);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Certificate not added :-( ");
                    }

                }
         
    }


    public class MyCertificateProvider : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values;
    }

    
  public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
 
}
