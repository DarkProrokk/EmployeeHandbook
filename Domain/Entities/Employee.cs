using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public DateOnly BirthDay { get; private set; }
        public Sex Sex { get; private set; }
        private Employee() { }

        private Employee(string fullname, DateOnly birthday, Sex sex) { 
            FullName = fullname;
            BirthDay = birthday;
            Sex = sex;
        }

        public static Employee CreateEmployee(string fullname, DateOnly birthday, Sex sex)
        {
            if (string.IsNullOrWhiteSpace(fullname)) throw new ArgumentNullException("Fullname can not be empty or null");
            if (birthday > DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException("BirthDay date can not be later than creation date");
            if (birthday <= DateOnly.FromDateTime(DateTime.Now.AddYears(-80))) throw new ArgumentException("BirthDay date can not be eairlier than 1925");
            if (birthday == DateOnly.MinValue) throw new ArgumentException("BirthDay date can not be empty");
            DateTime createdAt = DateTime.Now;
            var guid = System.Guid.NewGuid();
            return new Employee(fullname,birthday,sex);
        }
        public int CalculateAge()
        {
            var today = DateTime.Now.Date;
            var age = today.Year - BirthDay.Year;
            if (BirthDay > DateOnly.FromDateTime(today.AddYears(-age))) age--;
            return age;
        }

    }
    public enum Sex
    {
        Male,
        Female
    }
}
