using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePayroll
{
    public partial class PayrollForm : Form
    {
        PayrollCalculation payroll = new PayrollCalculation();
        GeneralFormat format = new GeneralFormat();

        public PayrollForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            payroll.EmpRateHour = 0;
            payroll.EmpHourDay = 0;
            payroll.EmpNumDay = 0;
        }

        private void rate_per_hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            format.decimalTextbox(sender, e);
        }

        private void hour_per_day_KeyPress(object sender, KeyPressEventArgs e)
        {
            format.decimalTextbox(sender, e);
        }

        private void num_days_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void rate_per_hour_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(rate_per_hour.Text))
                payroll.EmpRateHour = Double.Parse(rate_per_hour.Text);
            else
                payroll.EmpRateHour = 0;

            calculateMoney();
        }

        private void hour_per_day_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(hour_per_day.Text))
                payroll.EmpHourDay = Double.Parse(hour_per_day.Text);
            else
                payroll.EmpHourDay = 0;

            calculateMoney();
        }

        private void num_days_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(num_days.Text))
                payroll.EmpNumDay = Int32.Parse(num_days.Text);
            else
                payroll.EmpNumDay = 0;

            calculateMoney();
        }

        public void calculateMoney()
        {
            double gross_salary = payroll.getGrossSalary(payroll.EmpHourDay, payroll.EmpRateHour, payroll.EmpNumDay);
            double monthly_wage = payroll.getMonthlyWage(gross_salary);
            double philhealth = payroll.getPhilhealth(gross_salary);
            double sss = payroll.getSSS(gross_salary);
            double deduction = payroll.getDeduction(monthly_wage, philhealth, sss);
            double net_salary = payroll.getNetSalary(gross_salary, deduction);

            monthly_wage_textbox.Text = format.moneyFormatPH(monthly_wage);
            philhealth_textbox.Text = format.moneyFormatPH(philhealth);
            sss_textbox.Text = format.moneyFormatPH(sss);
            gross_salary_textbox1.Text = format.moneyFormatPH(gross_salary);
            gross_salary_textbox2.Text = format.moneyFormatPH(gross_salary);
            deduction_textbox1.Text = format.moneyFormatPH(deduction);
            deduction_textbox2.Text = format.moneyFormatPH(deduction);
            net_salary_textbox.Text = format.moneyFormatPH(net_salary);
        }
    }
}
