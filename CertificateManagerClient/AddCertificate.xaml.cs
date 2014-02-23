using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient
{
    /// <summary>
    /// Interaction logic for AddCertificate.xaml
    /// </summary>
    public partial class AddCertificate : Page
    {
        public AddCertificate()
        {
            InitializeComponent();
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
                X509Certificate2 loadedCertificate = new X509Certificate2(ofd.FileName);
                System.Diagnostics.Debug.WriteLine("Reading Client Certificate Information");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void AddCertButton_Click(object sender, RoutedEventArgs e)
        {
            //instantiate web service
            CertificateManagerService.CertificateManagerServiceClient
                 wsref = new CertificateManagerService.CertificateManagerServiceClient();

            Certificate certificate = new Certificate();
            //certificate.Name = CertName.Text;
            //certificate.StartDate = Convert.ToDateTime(StartDate.Text);
            //certificate.EndDate = Convert.ToDateTime(EndDate.Text);
            //certificate.ExpirationDate = Convert.ToDateTime(ExpirationDate.Text);
            //certificate.Thumbprint = Thumbprint.Text;
            //try converting certificate content from text back to bytes (http://www.dotnetperls.com/convert-string-byte-array)
            certificate.Content = Encoding.ASCII.GetBytes(CertContent.Text);

            //this will probably work, but I may not need it:
            /*
            var file = "newCertFile.cer";
            try
            {
                File.WriteAllBytes(file, certificate.Content);
            }
            catch (Exception)
            {
                { }
                throw;
            }
            */
            // *** FOR TESTING -- NEED TO PASS THESE IN FROM THE PAGE SOMEHOW ***
            //create a unique subjectName
            //string subjectName = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            //509Store testStore = new X509Store();

            string newStoreName = Store.SelectedItem.ToString();
            X509Store store = new X509Store(newStoreName, StoreLocation.LocalMachine);
            
            
            X509Certificate2 certificate2 =
                new X509Certificate2(certificate.Content);

           bool added = wsref.InstallCertificateLocal(store, certificate2);

            if (added)
            {
                System.Diagnostics.Debug.WriteLine("Certificate was added");
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
            CertificateWarehouseService.CertificateWarehouseServiceClient
                wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();
            
            //new CertificateManager Certificate
            Certificate certificate = new Certificate();
            //certificate.Name = CertName.Text;
            //certificate.StartDate = Convert.ToDateTime(StartDate.Text);
            //certificate.EndDate = Convert.ToDateTime(EndDate.Text);
            //certificate.ExpirationDate = Convert.ToDateTime(ExpirationDate.Text);
            //certificate.Thumbprint = Thumbprint.Text;
            //try converting certificate content from text back to bytes (http://www.dotnetperls.com/convert-string-byte-array)
            certificate.Content = Encoding.ASCII.GetBytes(CertContent.Text);
            
        bool added = wsref.AddCertificateToDatabase(certificate);

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
