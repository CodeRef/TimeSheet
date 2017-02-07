using System;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class UserProfile : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        //public virtual List<Address> Address { get; set; }
    }
}