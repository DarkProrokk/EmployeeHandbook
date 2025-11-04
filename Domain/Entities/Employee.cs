using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly BirthDay { get; set; }
        public Sex Sex { get; set; }

    }
    public enum Sex
    {
        Male,
        Female
    }
}
