using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CertificateManagerClient.TestUtilities.TestUtilities;

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

            // *** FOR TESTING -- NEED TO PASS THESE IN FROM THE PAGE SOMEHOW ***
            //create a unique subjectName
            string subjectName = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);

            X509Store store = new X509Store("CA", StoreLocation.LocalMachine);
            X509Certificate2 certificate =
                new X509Certificate2(CreateCertificate.CreateSelfSignedCertificate(subjectName));

           bool added = wsref.InstallCertificateLocal(store, certificate);

            if (added)
            {
                System.Diagnostics.Debug.WriteLine("Certificate was added");
            }
        }
    }
}
