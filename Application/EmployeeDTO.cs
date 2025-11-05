using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public DateOnly BirthDay { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
    }
}
