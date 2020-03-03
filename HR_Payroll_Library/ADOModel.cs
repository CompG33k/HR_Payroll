namespace HR_Payroll_Library
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ADOModel : DbContext
    {
        public ADOModel()
            : base("name=ADOModel")
        {
        }

        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefit>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Benefit>()
                .Property(e => e.bcode)
                .IsFixedLength();

            modelBuilder.Entity<Benefit>()
                .Property(e => e.description)
                .IsFixedLength();

            modelBuilder.Entity<Dependent>()
                .Property(e => e.fname)
                .IsFixedLength();

            modelBuilder.Entity<Dependent>()
                .Property(e => e.lname)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.fname)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.lname)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.benefits)
                .IsUnicode(false);
        }
    }
}
