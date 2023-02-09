using System;

namespace Homework.Task11
{
    [Serializable]
    public class Employee
    {
        //фамилии, имени, отчеству, номеру телефона или адресу сотрудника

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patron { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Employee()
        {
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Patron} - Phone: {Phone}, Address: {Address}";
        }

    }
}
