
using Application.Interfaces;
using System.Diagnostics;

namespace Application.Command
{
    public class SelectFromTableByCriterion(IEmployeeService service) : ICommand
    {
        public async Task Execute(string[] args)
        {
            var employees = await service.OutputRecordsByFilterAsync();

            Console.WriteLine("Список сотрудников по критерию: пол мужской, Фамилия начинается с \"F\":");
            Console.WriteLine("ФИО\t\t\tДата рождения\tПол\tВозраст");
            Console.WriteLine(new string('-', 60));


            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FullName}\t{emp.BirthDay:yyyy-MM-dd}\t{emp.Sex}\t{emp.Age}");
            }
        }
    }
}
