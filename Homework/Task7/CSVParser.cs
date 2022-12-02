using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework.Task7
{

    public class CSVParser
    {

        private static readonly FORMAT format = FORMAT.WITH_HEADERS;
        private static readonly char itemSeparator = '\t';
        private static readonly char itemQuote = '\"';
        private static readonly Regex phoneRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
        private static readonly Regex emailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
        public static void Main(string[] args)
        {
            parse(args[0]);
        }

        public static void parse(string fileName)
        {
            readLines(fileName);
        }

        private static void readLines(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var employees = new LinkedList<Employee>();
            var validPhoneCount = 0;
            var validEmailCount = 0;
            for (var i = (int)format; i < lines.Length; i++)
            {
                var empl = new Employee();
                var line = lines[i];
                var fields = line.Split(itemSeparator);
                empl.Name = fields[0].Trim().Replace(itemQuote.ToString(), string.Empty);
                empl.Email = fields[1].Trim().Replace(itemQuote.ToString(), string.Empty);
                empl.Phone = fields[2].Trim().Replace(itemQuote.ToString(), string.Empty);
                empl.EmailValid = testEmailValid(empl.Email);
                empl.PhoneValid = testPhoneValid(empl.Phone);

                validEmailCount += Convert.ToInt32(empl.EmailValid);
                validPhoneCount += Convert.ToInt32(empl.PhoneValid);
                employees.AddLast(empl);
            }

            Console.WriteLine($"Total employees: {employees.Count}");
            Console.WriteLine($"Phones valid: {validPhoneCount}, invalid: {employees.Count - validPhoneCount}");
            Console.WriteLine($"Emails valid: {validEmailCount}, invalid: {employees.Count - validEmailCount}");
        }

        private static bool testEmailValid(string email)
        {
            return emailRegex.IsMatch(email);
        }

        private static bool testPhoneValid(string phone)
        {
            return phoneRegex.IsMatch(phone);
        }

        private enum FORMAT
        {
            DEFAULT,
            WITH_HEADERS
        }
    }
}
