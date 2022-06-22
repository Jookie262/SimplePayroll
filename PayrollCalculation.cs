using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    class PayrollCalculation : PayrollDetails
    {
        public override double getDeduction(double monthlyWage, double philHealth, double sss)
        {
            return monthlyWage + philHealth + sss;
        }

        public override double getGrossSalary(double hourDay, double rateHour, int numDays)
        {
            return hourDay * rateHour * numDays;
        }

        public override double getMonthlyWage(double grossSalary)
        {
            return grossSalary * 0.15;
        }

        public override double getNetSalary(double grossSalary, double deduction)
        {
            return grossSalary - deduction;
        }

        public override double getPhilhealth(double grossSalary)
        {
            return grossSalary * 0.05;
        }

        public override double getSSS(double grossSalary)
        {
            return grossSalary * 0.02;
        }
    }
}
