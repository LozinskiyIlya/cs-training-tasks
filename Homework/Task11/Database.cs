using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Homework.Task11
{
    public class Database : IDisposable
    {
        private static readonly string FILE_PATH = @"Task11/";
        private static readonly string FILE_NAME = FILE_PATH + "db.txt";
        private bool disposedValue;
        private StreamWriter db;
        private List<Employee> employees;

        public Database()
        {
            OpenDB();
            FetchEmployees();
        }

        public List<Employee> Find(Employee criteria)
        {

            return employees.FindAll(e =>
            {
                bool filter = true;
                if (criteria.FirstName != null)
                {
                    filter = filter && e.FirstName.Equals(criteria.FirstName);
                }
                if (criteria.LastName != null)
                {
                    filter = filter && e.LastName.Equals(criteria.LastName);
                }
                if (criteria.Patron != null)
                {
                    filter = filter && e.Patron.Equals(criteria.Patron);
                }
                if (criteria.Phone != null)
                {
                    filter = filter && e.Phone.Equals(criteria.Phone);
                }
                if (criteria.Address != null)
                {
                    filter = filter && e.Address.Equals(criteria.Address);
                }
                return filter;
            });
        }

        public void Add(Employee employee)
        {
            string dbData = JsonConvert.SerializeObject(employee);
            // json array workaround
            db.Write(",");
            db.WriteLine(dbData);
            employees.Add(employee);
            db.Flush();
        }

        private void OpenDB()
        {
            FileStream fileStream = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            db = new StreamWriter(fileStream, Encoding.UTF8, 1024, true);
        }

        private void FetchEmployees()
        {
            using (StreamReader streamReader = new StreamReader(db.BaseStream, Encoding.UTF8, false, 1024, true))
            {
                string dbData = streamReader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(dbData))
                {
                    employees = new List<Employee>();
                    return;
                }
                // json array workaround
                dbData = "[" + dbData + "]";
                var fetched = JsonConvert.DeserializeObject<List<Employee>>(dbData);
                employees = fetched;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    employees.Clear();
                }

                try
                {
                    db.Flush();
                    db.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while disposing: " + e.Message);
                }

                disposedValue = true;
            }
        }

        ~Database()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
