using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayroll
{
    abstract class PayrollDetails
    {
        private string name;
        private double rateHour, hourDay;
        private int numDay;

        // Getter and Setter of each variable

        public string EmpName
        {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        public double EmpRateHour
        {
            get
            {
                return this.rateHour;
            }
            set
            {
                this.rateHour = value;
            }
        }

        public double EmpHourDay
        {
            get
            {
                return this.hourDay;
            }
            set
            {
                this.hourDay = value;
            }
        }

        public int EmpNumDay
        {
            get
            {
                return this.numDay;
            }
            set
            {
                this.numDay = value;
            }
        }

        // Methods that need to define
        public abstract double getMonthlyWage(double grossSalary);
        public abstract double getPhilhealth(double grossSalary);
        public abstract double getSSS(double grossSalary);
        public abstract double getGrossSalary(double hourDay, double rateHour, int numDays);
        public abstract double getDeduction(double monthlyWage, double philHealth, double sss);
        public abstract double getNetSalary(double grossSalary, double deduction);
    }
}
