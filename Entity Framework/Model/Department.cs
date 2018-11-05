
namespace EmployeeTracker.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Department
    {
        private ICollection<Employee> employees;

        public Department()
        {

        }

        public virtual int DepartmentId { get; set; }

        public virtual string DepartmentName { get; set; }

        public virtual string DepartmentCode { get; set; }

        public virtual DateTime? LastAudited { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }
    }
}
