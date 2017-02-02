using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace customDigi
{
    public class manager
    {
        printUtil p = new printUtil();
        public void menu()
        {
            string user = Environment.UserName;
            //p.write(p.br + "1) Clock" + p.br + "2) Stopwatch" + p.br + "X) Exit", p.cyan);
            p.write(p.br + "1", p.cyan);
            p.write(") Clock", p.wht);
            p.write(p.br + "2", p.cyan);
            p.write(") Stopwatch", p.wht);
            p.write(p.br + "X", p.cyan);
            p.write(") Exit", p.wht);
            ConsoleKeyInfo k = p.rk(p.br + "Select: ", p.wht, p.cyan);
            switch (k.KeyChar)
            {
                case '1':
                    Console.Title = "12-Hour Clock on " + user + "'s PC.";
                    getCurrentTime();
                    break;
                case '2':
                    Console.Title = "Stopwatch on " + user + "'s PC.";
                    p.write(p.br + "Press ", p.wht);
                    p.write("ENTER", p.grn);
                    p.write(" now to start the stopwatch. (", p.wht);
                    p.write("ENTER", p.grn);
                    ConsoleKeyInfo kk = p.rk(" also stops stopwatch.)", p.wht, p.cyan);
                    if(kk.Key == ConsoleKey.Enter) { stopwatchHome(kk); }
                    else { p.write(p.br + "Invalid Keystroke.", p.red); }
                    break;
                case 'x':
                case 'X':
                    Environment.Exit(0);
                    break;
                default:
                    p.clear();
                    menu();
                    break;
            }
            p.write(p.br + "Returning to menu.", p.cyan);
            p.rest(1000);
            p.clear();
            menu();
        }
        public void stopwatchHome(ConsoleKeyInfo k)
        {
            if(k.Key == ConsoleKey.Enter)
            {
                TimeSpan startTime = getTime();
                TimeSpan newTime = new TimeSpan();
                TimeSpan stopTime = new TimeSpan();
                time timeChars = new time();
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        newTime = getTime();
                        stopTime = newTime.Subtract(startTime);
                        p.clear();
                        printTime(formatTime(buildTime(timeToCharArray(stopTime.ToString(), true), true)));
                        p.rest(100);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                p.write(p.br + "Press ", p.wht);
                p.write("ENTER", p.grn);
                p.write(" to reset stopwatch or ", p.wht);
                p.write("ESCAPE", p.red);
                ConsoleKeyInfo kk = p.rk(" to return to main menu.", p.wht, p.red);
                switch (kk.Key)
                {
                    case ConsoleKey.Enter:
                        stopwatchHome(k);
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            }
        }
        public void getCurrentTime()
        {

            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.Clear();
                    p.write(p.br + "Press ", p.wht);
                    p.write("ESCAPE", p.red);
                    p.write(" to return to the previous menu.", p.wht);
                    printTime(formatTime(buildTime(timeToCharArray(getTime().ToString(), false), false)));
                    Thread.Sleep(1000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public List<string> formatTime(List<string[]> currentTime)
        {
            List<string> formattedTime = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                formattedTime.Add("");
            }
            foreach (string[] digit in currentTime)
            {
                formattedTime[0] += digit[0];
                formattedTime[1] += digit[1];
                formattedTime[2] += digit[2];
                formattedTime[3] += digit[3];
                formattedTime[4] += digit[4];
                formattedTime[5] += digit[5];
            }
            return formattedTime;

        }
        public List<string[]> buildTime(time timeToPrint, bool stopwatch)
        {
            List<string[]> currentTime = new List<string[]>();
            for (int i = 0; i < timeToPrint.hours.Count(); i++)
            {
                currentTime.Add(getNumString(timeToPrint.hours[i]));
            }
            currentTime.Add(p.colon);
            for (int i = 0; i < timeToPrint.minutes.Count(); i++)
            {
                currentTime.Add(getNumString(timeToPrint.minutes[i]));
            }
            currentTime.Add(p.colon);

            for (int i = 0; i < timeToPrint.seconds.Count(); i++)
            {
                currentTime.Add(getNumString(timeToPrint.seconds[i]));
            }
            if (stopwatch)
            {
                currentTime.Add(p.priod);
                currentTime.Add(getNumString(timeToPrint.mSecond));               
            }
            return currentTime;
        }
        public void printTime(List<string> formattedTime)
        {
            foreach (string _line in formattedTime)
            {
                p.write(p.br + _line, p.cyan);
            }
        }
        public TimeSpan getTime()
        {
            TimeSpan _thisTime = DateTime.Now.TimeOfDay;
            return _thisTime;
        }
        public time timeToCharArray(string timeRAW, bool stopwatch)
        {
            time thisTime = new time();
            string[] timeSplit = timeRAW.Split(':');
            int hours;
            bool result = int.TryParse(timeSplit[0], out hours);
            if (result && !stopwatch)
            {
                if (hours > 12)
                {
                    hours -= 12;
                    thisTime.hours = hours.ToString().ToCharArray();
                    timeSplit[2] = timeSplit[2].Substring(0, 2) + " PM"; 
                }
                else
                {
                    thisTime.hours = hours.ToString().ToCharArray();
                    timeSplit[2] = timeSplit[2].Substring(0, 2) + " AM";
                }
            }
            else if(result && stopwatch)
            {
                thisTime.hours = hours.ToString().ToCharArray();
            }
            thisTime.minutes = timeSplit[1].ToCharArray();
            thisTime.seconds = timeSplit[2].Split('.').First().ToCharArray();
            thisTime.mSecond = timeSplit[2].Split('.').Last().Substring(0,1).ToCharArray()[0];
            return thisTime;
        }
        public string[] getNumString(char digit)
        {
            string[] currentDigit = { };
            switch (digit)
            {
                case '0':
                    currentDigit = p._zero;
                    break;
                case '1':
                    currentDigit = p.__one;
                    break;
                case '2':
                    currentDigit = p.__two;
                    break;
                case '3':
                    currentDigit = p.three;
                    break;
                case '4':
                    currentDigit = p._four;
                    break;
                case '5':
                    currentDigit = p._five;
                    break;
                case '6':
                    currentDigit = p.__six;
                    break;
                case '7':
                    currentDigit = p.seven;
                    break;
                case '8':
                    currentDigit = p.eight;
                    break;
                case '9':
                    currentDigit = p._nine;
                    break;
                case ' ':
                    currentDigit = p.space;
                    break;
                case '.':
                    currentDigit = p.priod;
                    break;
                case 'A':
                    currentDigit = p.____a;
                    break;
                case 'P':
                    currentDigit = p.____p;
                    break;
                case 'M':
                    currentDigit = p.____m;
                    break;
            }
            return currentDigit;
        }
    }
}
