
namespace EmployeeTracker.Model
{
    using System;
    using System.Collections.Generic;

    public class Address : ContactDetail
    {
        private static string[] validUsageValues = new string[] { "Business", "Home", "Mailing" };

        public override IEnumerable<string> ValidUsageValues
        {
            get
            {
                return validUsageValues;
            }
        }

        public virtual string LineOne { get; set; }

        public virtual string LineTwo { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string ZipCode { get; set; }

        public virtual string Country { get; set; }
    }
}
