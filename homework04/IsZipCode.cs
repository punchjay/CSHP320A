using System.Text.RegularExpressions;
using System.Windows;

namespace homework04
{
    class IsZipCode
    {
        public IsZipCode()
        {
        }

        public IsZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }

        public bool ZCode(string zipCode)
        {
            string usPattern = @"^\d{5}(\-\d{4})?$";
            string caPattern = @"^[A-Z]\d[A-Z]( )?\d[A-Z]\d$/i";

            Regex usRegex = new Regex(usPattern);
            Regex caRegex = new Regex(caPattern);

            bool usZipCode = usRegex.IsMatch(zipCode);
            bool caZipCode = caRegex.IsMatch(zipCode);
            bool isZipCodeMatch = usZipCode || caZipCode;

            MainWindow uiMain = ((MainWindow)System.Windows.Application.Current.MainWindow);

            if (isZipCodeMatch)
            {
                MessageBox.Show(usZipCode.ToString());
                uiMain.uxSubmitZipCodeBt.IsEnabled = true;
            }
            else
            {
                uiMain.uxSubmitZipCodeBt.IsEnabled = false;
            }
            return isZipCodeMatch;
        }

        private string _zipCode;

        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
            }
        }
    }
}
