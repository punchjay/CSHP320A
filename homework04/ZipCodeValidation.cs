using System.Text.RegularExpressions;

namespace homework04
{
    class ZipCodeValidation
    {
        public ZipCodeValidation()
        {
            ZipCode = "98017";
        }

        public ZipCodeValidation(string zipCode)
        {
            ZipCode = zipCode;
        }

        public bool IsZipCodeValid(string zipCode)
        {
            string usPattern = @"^\d{5}(\-\d{4})?$";
            string caPattern = @"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$";

            Regex usRegex = new Regex(usPattern);
            Regex caRegex = new Regex(caPattern);

            bool usZipCode = usRegex.IsMatch(zipCode);
            bool caZipCode = caRegex.IsMatch(zipCode);
            bool isZipCodeMatch = usZipCode || caZipCode;

            MainWindow uiMain = ((MainWindow)System.Windows.Application.Current.MainWindow);

            if (isZipCodeMatch)
            {
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
