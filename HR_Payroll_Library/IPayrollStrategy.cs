using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    interface IPayrollStrategy
    {
        void Get(BCode benefitType,IPerson person);
        bool Apply(BCode benefitType, IPerson person);
        bool Deduct(BCode benefitType, IPerson person);
    }
}
