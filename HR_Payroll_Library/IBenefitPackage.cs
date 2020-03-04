using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public interface IBenefitPackage
    {
        BCode BenefitType { get;  }
        int Amount(Employee person,IEnumerable<Dependent> dependents);
        string GetType();
    }
}
