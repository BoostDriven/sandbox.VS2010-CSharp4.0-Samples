
namespace EmployeeTracker.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;

    public class Employee
    {
        private ICollection<ContactDetail> details;

        private ICollection<Employee> reports;

        private Department department;

        private Employee manager;

        public Employee()
        {
            this.details = new ObservableCollection<ContactDetail>();

            // Wire up the reports collection to sync references
            // NOTE: When running against Entity Framework with change tracking proxies this logic will not get executed
            //       because the Reports property will get over-ridden and replaced with an EntityCollection<Employee>.
            //       The EntityCollection will perform this fixup instead.
            ObservableCollection<Employee> reps = new ObservableCollection<Employee>();
            this.reports = reps;
            reps.CollectionChanged += (sender, e) =>
            {
                // Set the reference on any employee being added to this manager
                if (e.NewItems != null)
                {
                    foreach (Employee item in e.NewItems)
                    {
                        if (item.Manager != this)
                        {
                            item.Manager = this;
                        }
                    }
                }

                if (e.OldItems != null)
                {
                    foreach(Employee item in e.OldItems)
                    {
                        if (item.Manager == this)
                        {
                            item.Manager = null;
                        }
                    }
                }
            };
        }

        public virtual int EmployeeId { get; set; }

        public virtual string Title { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Position { get; set; }

        public virtual DateTime HireDate { get; set; }

        public virtual DateTime? TerminationDate { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual int? DepartmentId { get; set; }

        public virtual int? ManagerId { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public virtual ICollection<Employee> Reports
        {
            get { return this.reports; }
            set { this.reports = value; }
        }

        public virtual Department Department
        {
            get { return this.department; }

            set
            {
                if (value != this.department)
                {
                    Department original = this.department;
                    this.department = value;

                    // Remove from old collection
                    if (original != null && original.Employees.Contains(this))
                    {
                        original.Employees.Remove(this);
                    }

                    // Add to new collection
                    if (value != null && !value.Employees.Contains(this))
                    {
                        value.Employees.Add(this);
                    }
                }
            }
        }

        public virtual Employee Manager
        {
            get { return this.manager; }

            set
            {
                if (value != this.manager)
                {
                    Employee original = this.manager;
                    this.manager = value;

                    // Remove from old collection
                    if (original != null && original.Reports.Contains(this))
                    {
                        original.Reports.Remove(this);
                    }

                    // Add to new collectionf
                    if (value != null && !value.Reports.Contains(this))
                    {
                        value.Reports.Add(this);
                    }
                }
            }
        }
    }
}
