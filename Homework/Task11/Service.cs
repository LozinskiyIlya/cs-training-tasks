using System;
namespace Homework.Task11
{
    public class Service
    {
        private Database database;
        private static readonly string HELP =
            "Commands:\n"
            +
            "\'Find\' - find employees\n"
            +
            "\'Add\' - add new employee\n"
            +
            "\'Exit\' - stop service\n\n";

        private static readonly string FIND_HELP =
            "\nSpecify first and last name, patronymic, phone, address\n"
            +
            "To skip any field - press \'Enter\'\n"
            +
            "Note: if you skip all fields, you will see entire employees list\n\n";

        private static readonly string ADD_HELP = "\nSpecify first and last name, patronymic, phone, address\n"
            +
            "To skip any field - press \'Enter\'\n"
            +
            "Note: at least firstname, lastname and phone should be specified\n\n";

        private static readonly string ADD_ERROR = "At least firstname, lastname and phone should be specified!\n";

        public Service()
        {

        }

        public void Start()
        {
            Console.WriteLine("Starting Service...");
            Console.WriteLine("Openning Database...");
            database = new Database();
            Console.WriteLine("Ready.");
            string input;
            while (true)
            {
                Console.WriteLine(HELP);
                input = Console.ReadLine();
                switch (input.Trim().ToLower())
                {
                    case "find":
                        Find();
                        break;
                    case "add":
                        Add();
                        break;
                    case "exit":
                        Console.WriteLine("Stopping service...");
                        return;

                }
            }
        }

        private void Find()
        {
            Console.WriteLine(FIND_HELP);

            var criteria = ParseInput();
            var fetched = database.Find(criteria);

            Console.WriteLine("\nResult:\n");
            foreach (var emp in fetched)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();
        }

        private void Add()
        {
            Console.WriteLine(ADD_HELP);

            var employee = ParseInput();
            Console.WriteLine(employee);

            if (string.IsNullOrWhiteSpace(employee.FirstName) &&
                string.IsNullOrWhiteSpace(employee.LastName) &&
                string.IsNullOrWhiteSpace(employee.Phone))
            {
                Console.WriteLine(ADD_ERROR);
                return;
            }

            database.Add(employee);
        }

        private Employee ParseInput()
        {
            var employee = new Employee();
            Console.WriteLine("First name: ");
            string nextInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nextInput))
            {
                employee.FirstName = nextInput;
            }
            Console.WriteLine("Last name: ");
            nextInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nextInput))
            {
                employee.LastName = nextInput;
            }
            Console.WriteLine("Patronymic: ");
            nextInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nextInput))
            {
                employee.Patron = nextInput;
            }
            Console.WriteLine("Phone: ");
            nextInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nextInput))
            {
                employee.Phone = nextInput;
            }
            Console.WriteLine("Address: ");
            nextInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nextInput))
            {
                employee.Address = nextInput;
            }

            return employee;
        }
    }
}
