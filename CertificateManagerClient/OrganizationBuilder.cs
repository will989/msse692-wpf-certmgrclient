using System;
using System.Text;
using System.Windows.Data;

namespace CertificateManagerClient
{
    internal class OrganizationBuilder : IMultiValueConverter

    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            StringBuilder OrganizationBuilder = new StringBuilder();
            foreach (object name in values)
            {
                OrganizationBuilder.AppendFormat("{0} ", name.ToString());
            }
            return OrganizationBuilder.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();

        }
    }
}
