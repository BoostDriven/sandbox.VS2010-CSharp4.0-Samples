

namespace EmployeeTracker.Model
{
    using System.Collections.Generic;

    public abstract class ContactDetail
    {
        public abstract IEnumerable<string> ValidUsageValues { get; }
        public virtual int ContactDetailId { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual string Usage { get; set; }
    }
}
