using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    class GeneralFormat
    {
        public string moneyFormatPH(double dec)
        {
            return string.Format(new CultureInfo("en-PH"), "{0:C}", dec);
        }

        public void decimalTextbox(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !char.IsControl(e.KeyChar);
            if ((e.KeyChar == '.') && ((sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }
    }
}
