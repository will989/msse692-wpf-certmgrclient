using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CertificateManagerClient.CertificateWarehouseService;

//Here is the once-per-application setup information
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
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
            log.Debug("Initializing app");
            
        }
        //Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       }
    }
