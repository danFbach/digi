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
                if(i == 2)
                {
                    currentTime.Add(pu.priod);
                }
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
            thisTime.hours = timeSplit[0].ToCharArray();
            thisTime.minutes = timeSplit[1].ToCharArray();
            string[] secs = timeSplit[2].Split('.');
            string second = secs[0] + secs[1];
            thisTime.seconds = second.Substring(0, 3).ToCharArray();
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
            }
            return currentDigit;
        }
    }
}
