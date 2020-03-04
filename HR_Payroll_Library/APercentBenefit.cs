using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public class APercentBenefit:IBenefitPackage
    {
        int percent = 10;

        public BCode BenefitType { get; }
        public APercentBenefit()
        {
            BenefitType  = BCode.A_Name;
        }
        public int Amount(Employee employee, IEnumerable<Dependent> dependents)
        {
            // now you need to get first name and check A 
            if (employee.fname.ToLower().StartsWith("a"))
            {
                return percent;
            }
            foreach(Dependent cur in dependents)
            {
                if (cur.fname.ToLower().StartsWith("a"))
                {
                    return percent;
                }
            }
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
