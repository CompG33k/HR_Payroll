using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public class PayrollStrategy :IPayrollStrategy
    {
        private readonly IEnumerable<IBenefitPackage> _benefits;

        public PayrollStrategy(IEnumerable<IBenefitPackage> benefits)
        {
            _benefits = benefits;
        }

        public int Amount(Employee employee,IEnumerable<Dependent> dependents, BCode code)
        {
            return _benefits.FirstOrDefault(b => b.BenefitType == code)?
              .Amount(employee,dependents) ?? throw new ArgumentNullException(nameof(BCode));
        }
        public string GetType()
        {
            return string.Empty;
        }
    }
}
