using System;
using System.IO;

namespace Homework.Task7
{
    public class Watcher : IDisposable

    {
        private FileSystemWatcher fsw;
        private StreamWriter logFile;
        private bool disposedValue;

        public static void Main(string[] args)
        {
            new Watcher().Watch(args[0], args[1]);
        }

        public void Watch(string folderName, string logFileName)
        {
            Console.WriteLine("Press enter to exit.");
            SetupWatcher(folderName);
            SetupLogFile(logFileName);
            Console.ReadLine();
            CleanResourses();
        }

        protected void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            LogEvent(e.Name, "CREATED");
        }

        protected void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            LogEvent(e.Name, "CHANGED");
        }

        protected void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            LogEvent(e.Name, "DELETED");
        }

        private void LogEvent(string fileName, string eventType)
        {
            DateTime now = DateTime.Now;
            string dateTime = now.ToString("dd MMM yy, HH:mm");
            string logLine = $"{dateTime}       {fileName}      {eventType}";
            logFile.WriteLine(logLine);
            Console.WriteLine(logLine);
        }

        private void SetupWatcher(string folderName)
        {
            fsw = new FileSystemWatcher(folderName, "*.cs");
            fsw.NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastWrite;
            fsw.Changed += OnFileChanged;
            fsw.Created += OnFileCreated;
            fsw.Deleted += OnFileDeleted;
            fsw.Error += OnError;

            fsw.IncludeSubdirectories = true;
            fsw.EnableRaisingEvents = true;
        }

        private void SetupLogFile(string logFileName)
        {
            string heading = "Date:     Time:        File:        ChangeType:";
            string underline = "_________________________________________________";

            Console.WriteLine(heading);
            Console.WriteLine(underline);

            if (File.Exists(logFileName))
            {
                logFile = File.AppendText(logFileName);
            }
            else
            {
                logFile = File.CreateText(logFileName);
                logFile.WriteLine(heading);
                logFile.WriteLine(underline);
            }
        }

        private void CleanResourses()
        {
            try
            {
                logFile.Flush();
                logFile.Close();
                fsw.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            var ex = e.GetException();
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                CleanResourses();
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}