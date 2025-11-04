using Application.Interfaces;
using Domain.Entities;

namespace Application.Command
{
    public class AddRecordCommand(IEmployeeService service, string[] args) : ICommand
    {
        public async Task Execute()
        {
            if (args.Length != 4)
            {
                Console.WriteLine("myApp 2 \"FullName\" YYYY-MM-DD Male/Female");
                return;
            }
            var fullName = args[1];
            var birthDate = DateOnly.Parse(args[2]);
            var gender = args[3];
            await service.CreateAsync(fullName, birthDate,Sex.Male == gender??Sex.Male:Sex.Female);
        }
    }
}
