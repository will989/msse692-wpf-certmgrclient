using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CertificateManagerClient.CertificateWarehouseService;

namespace CertificateManagerClient
{
    /// <summary>
    /// Interaction logic for CertificateManagerHome.xaml
    /// </summary>
    public partial class CertificateManagerHome : Page
    {
        public CertificateManagerHome()
        {
            InitializeComponent();
            Item = new Certificate();
        }
        //from here:  http://social.msdn.microsoft.com/Forums/vstudio/en-US/29b08a8a-9879-401d-92d6-181a93f3c792/select-a-file-in-a-wpf-application?forum=wpf
        private void Button_Click(object sender, RoutedEventArgs e)
        {

             System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();

             if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 this.CertChooser.Text = ofd.FileName;
             }

            try
            {
               
                {
                    //load certificate from selected file
                    X509Certificate2 loadedCertificate = new X509Certificate2(ofd.FileName);
                    System.Diagnostics.Debug.WriteLine("Reading Client Certificate Information");
                    
                    //null check to make sure certificate was loaded, then populate form
                    if (loadedCertificate.SubjectName.Name != null) CertName.Text = loadedCertificate.SubjectName.Name;
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Certificate Name was null, certificate not loaded correctly");
                    }
                    StartDate.Text = loadedCertificate.NotBefore.ToLongDateString();
                    EndDate.Text = loadedCertificate.NotAfter.ToLongDateString();
                    ExpirationDate.Text = loadedCertificate.NotAfter.ToLongDateString();
                    Thumbprint.Text = loadedCertificate.Thumbprint;
                    //try storing content this way (http://www.dotnetperls.com/convert-string-byte-array)
                    CertContent.Text = Encoding.ASCII.GetString(loadedCertificate.RawData);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw;
            }
            finally
            {
                //do something
            }
        }

        public Certificate Item

        {
            get
            {
                var objectDataProvider = FindResource("MyCertificateProvider") as ObjectDataProvider;
                if (objectDataProvider != null)
                    return objectDataProvider.ObjectInstance as Certificate;
                return null;
            }
            set
            {
                var objectDataProvider = FindResource("MyCertificateProvider") as ObjectDataProvider;
                if (objectDataProvider != null)
                    objectDataProvider.ObjectInstance = value;
            }
        }
 

        private void SaveCertButton_Click(object sender, RoutedEventArgs e)
        {

            //instantiate web service
            CertificateWarehouseService.CertificateWarehouseServiceClient
                wsref = new CertificateWarehouseService.CertificateWarehouseServiceClient();
            
            //new CertificateManager Certificate
            Certificate certificate = new Certificate();
            certificate.Name = CertName.Text;
            certificate.StartDate = Convert.ToDateTime(StartDate.Text);
            certificate.EndDate = Convert.ToDateTime(EndDate.Text);
            if (IsDeleted.IsChecked != null && (bool) IsDeleted.IsChecked)
            {
                certificate.IsDeleted = (bool)IsDeleted.IsChecked;  
            }
            else
            {
                certificate.IsDeleted = false;
            }
            certificate.ExpirationDate = Convert.ToDateTime(ExpirationDate.Text);
            certificate.Thumbprint = Thumbprint.Text;
            //try converting certificate content from text back to bytes (http://www.dotnetperls.com/convert-string-byte-array)
            certificate.Content = Encoding.ASCII.GetBytes(CertContent.Text);
            
        bool added = wsref.AddCertificateToDatabase(certificate);

            if (added)
            {
                System.Diagnostics.Debug.WriteLine("Certificate added!");
                System.Diagnostics.Debug.WriteLine("Certificate Thumbprint = {0}", certificate.Thumbprint);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Certificate not added :-( ");
            }

        }


        private void IsDeleted_OnChecked_Checked(object sender, RoutedEventArgs e)
        {
            {

                IsDeleted.Content = "Checked";

            }

        }

        private void IsDeleted_Unchecked(object sender, RoutedEventArgs e)
        {
            IsDeleted.Content = "Unchecked";
        }
    }
    }
