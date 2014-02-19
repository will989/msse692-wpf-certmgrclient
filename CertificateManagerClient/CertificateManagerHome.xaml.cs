using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

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
        }
        //from here:  http://social.msdn.microsoft.com/Forums/vstudio/en-US/29b08a8a-9879-401d-92d6-181a93f3c792/select-a-file-in-a-wpf-application?forum=wpf
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
             if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 this.CertChooser.Text = ofd.FileName;
             }
         }
        }
    }
