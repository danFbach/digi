using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customDigi
{
    class Program
    {
        static void Main(string[] args)
        {
            manager run = new manager();
            Console.SetWindowSize(80, 8);
            string user = Environment.UserName;
            Console.Title = "Hello " + user + "! Welcome to the Custom Digi utility.";
            run.menu();
        }
    }
}
