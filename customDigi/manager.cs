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
        printUtil pu = new printUtil();
        public void getCurrentTime()
        {
            Console.Clear();
            timeManager();
            Thread.Sleep(100);
            getCurrentTime();
        }
        public void timeManager()
        {
            List<char> timeDigits = new List<char>();
            List<string[]> currentTime = new List<string[]>();
            List<string> formattedTime = new List<string>();
            for(int i = 0; i < 6; i++)
            {
                formattedTime.Add("");
            }
            time curTime = new time();
            curTime = getTime();
            for (int i = 0; i < curTime.hours.Count(); i++)
            {
                currentTime.Add(getNumString(curTime.hours[i]));
            }
            currentTime.Add(pu.colon);
            for (int i = 0; i < curTime.minutes.Count(); i++)
            {
                currentTime.Add(getNumString(curTime.minutes[i]));
            }
            currentTime.Add(pu.colon);
            
            for (int i = 0; i < curTime.seconds.Count(); i++)
            {
                currentTime.Add(getNumString(curTime.seconds[i]));
            }
            foreach(string[] digit in currentTime)
            {
                formattedTime[0] += digit[0];
                formattedTime[1] += digit[1];
                formattedTime[2] += digit[2];
                formattedTime[3] += digit[3];
                formattedTime[4] += digit[4];
                formattedTime[5] += digit[5];
            }
            foreach(string _line in formattedTime)
            {
                pu.write(pu.br + _line, pu.grn);
            }
        }
        public time getTime()
        {
            time thisTime = new time();
            string timeRAW = DateTime.Now.TimeOfDay.ToString();
            string[] timeSplit = timeRAW.Split(':');
            int hours;
            bool result = int.TryParse(timeSplit[0], out hours);
            if (result)
            {
                if (hours > 12)
                {
                    hours -= 12;
                    thisTime.hours = hours.ToString().ToCharArray();
                    timeSplit[2] = timeSplit[2].Substring(0, 4) + " PM";
                }
                else
                {
                    thisTime.hours = hours.ToString().ToCharArray();
                    timeSplit[2] = timeSplit[2].Substring(0, 4) + " AM";
                }
            }
            thisTime.minutes = timeSplit[1].ToCharArray();
            thisTime.seconds = timeSplit[2].ToCharArray();
            return thisTime;
        }
        public string[] getNumString(char digit)
        {
            string[] currentDigit = { };
            switch (digit)
            {
                case '0':
                    currentDigit = pu._zero;
                    break;
                case '1':
                    currentDigit = pu.__one;
                    break;
                case '2':
                    currentDigit = pu.__two;
                    break;
                case '3':
                    currentDigit = pu.three;
                    break;
                case '4':
                    currentDigit = pu._four;
                    break;
                case '5':
                    currentDigit = pu._five;
                    break;
                case '6':
                    currentDigit = pu.__six;
                    break;
                case '7':
                    currentDigit = pu.seven;
                    break;
                case '8':
                    currentDigit = pu.eight;
                    break;
                case '9':
                    currentDigit = pu._nine;
                    break;
                case ' ':
                    currentDigit = pu.space;
                    break;
                case '.':
                    currentDigit = pu.priod;
                    break;
                case 'A':
                    currentDigit = pu.____a;
                    break;
                case 'P':
                    currentDigit = pu.____p;
                    break;
                case 'M':
                    currentDigit = pu.____m;
                    break;
            }
            return currentDigit;
        }
    }
}
