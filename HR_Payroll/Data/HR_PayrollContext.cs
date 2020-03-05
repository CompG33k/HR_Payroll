using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HR_Payroll_Library;

namespace HR_Payroll.Data
{
    public class HR_PayrollContext : DbContext
    {
        public HR_PayrollContext (DbContextOptions<HR_PayrollContext> options)
            : base(options)
        {
        }
        public DbSet<HR_Payroll_Library.Employee> Employee { get; set; }
        public DbSet<HR_Payroll_Library.Dependent> Dependent { get; set; }
        public DbSet<HR_Payroll_Library.Benefit> Benefit { get; set; }
        public IQueryable<HR_Payroll_Library.GetEmployeeSummary_Result> GetEmployeeSummary_Result { get; set; }
    }
}
