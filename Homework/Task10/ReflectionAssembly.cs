using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Task10
{
    public class ReflectionAssembly
    {
        public static void Main(string[] args)
        {
            new ReflectionAssembly().Start();
            Console.ReadKey();
        }
        public void Start()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach(var a in assemblies){
                Console.WriteLine(a.GetName());
            }
        }
    }
}
