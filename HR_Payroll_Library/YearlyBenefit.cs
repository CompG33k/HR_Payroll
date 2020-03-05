using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public class YearlyBenefit : IBenefitPackage
    {
        int perYearAmount = 1000;

        public BCode BenefitType { get; }
        public YearlyBenefit()
        {
            BenefitType = BCode.PerYear;
        }
        public int Amount(Employee employee, IEnumerable<Dependent> dependents)
        {
           

            // now you need to get a list of all dependents with first name A and count value amount
            // return the calculated person amount..
            return 0;
        }
        public string GetType()
        {
            return string.Empty;
        }
    }
}
