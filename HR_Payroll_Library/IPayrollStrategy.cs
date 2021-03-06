﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public interface IPayrollStrategy
    {
        int Amount(Employee person,IEnumerable<Dependent> dependents,BCode code);
        string GetType();
    }
}
