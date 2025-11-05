using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RecordGeneratorService(IEmployeeRepository repository) : IRecordGeneratorService
    {
        private static readonly string[] FirstNames = {
        "James", "John", "Robert", "Michael", "William",
        "David", "Richard", "Joseph", "Thomas", "Charles",
        "Christopher", "Daniel", "Matthew", "Anthony", "Donald",
        "Mark", "Paul", "Steven", "Andrew", "Kenneth",
        "Joshua", "Kevin", "Brian", "George", "Edward",
        "Mary", "Jennifer", "Linda", "Patricia", "Elizabeth",
        "Susan", "Jessica", "Sarah", "Karen", "Nancy",
        "Lisa", "Betty", "Sandra", "Ashley", "Kimberly",
        "Donna", "Michelle", "Dorothy", "Laura", "Amy"
    };

        private static readonly string[] LastNames = {
        "Smith", "Johnson", "Williams", "Brown", "Jones",
        "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
        "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson",
        "Thomas", "Taylor", "Moore", "Jackson", "Martin",
        "Lee", "Perez", "Thompson", "White", "Harris",
        "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
        "Walker", "Young", "Allen", "King", "Wright",
        "Scott", "Torres", "Nguyen", "Hill",
        "Green", "Adams", "Nelson", "Baker", "Hall",
        "Rivera", "Campbell", "Mitchell", "Carter", "Roberts"
    };

        private static readonly string[] MiddleNames = {
        "Alexander", "Benjamin", "Caleb", "Daniel", "Elijah",
        "Gabriel", "Henry", "Isaac", "Jacob", "Lucas",
        "Mason", "Noah", "Oliver", "Samuel", "Theodore",
        "Ava", "Charlotte", "Eleanor", "Grace", "Harper",
        "Lily", "Madison", "Natalie", "Olivia", "Sophia"
    };

        public async Task GenerateBulk(int count)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var fullname = GenerateRandomFullname(random);
                var sex = GenerateRandomSex(i);
                var birthDay = GenerateRandomBirthDate(random);

                var employee = Employee.CreateEmployee(fullname, birthDay, sex);
                await repository.AddEmployee(employee);
            }
            await repository.SaveAsync();
        }

        public async Task GenerateSpecialFEmployees(int count = 100)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var fullname = $"F{GenerateRandomFullname(random)}";
                var birthDay = GenerateRandomBirthDate(random);

                var employee = Employee.CreateEmployee(fullname, birthDay, Sex.Male);
                await repository.AddEmployee(employee);
            }
            await repository.SaveAsync();
        }
        private string GenerateRandomFullname(Random random)
        {
            var firstName = FirstNames[random.Next(FirstNames.Length)];
            var lastName = LastNames[random.Next(LastNames.Length)];
            var middleName = MiddleNames[random.Next(MiddleNames.Length)];

            return $"{lastName} {firstName} {middleName}";
        }
        private Sex GenerateRandomSex(int i)
        {
            if (i % 2 == 0)
            {
                return Sex.Female;
            }
            else
            {
                return Sex.Male;
            }
        }
        private DateOnly GenerateRandomBirthDate(Random random)
        {
            var startDate = new DateOnly(1980, 1, 1);
            var endDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-18));
            var range = endDate.DayNumber - startDate.DayNumber;
            return DateOnly.FromDayNumber(startDate.DayNumber + random.Next(range));
        }
    }
}

