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
            Console.SetWindowSize(Console.WindowWidth, 8);
            string user = Environment.UserName;
            Console.Title = "24-Hour Clock on " + user + "'s PC.";
            run.getCurrentTime();
        }
    }
}
