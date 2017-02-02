using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace customDigi
{
    public class printUtil
    {
        #region color vars and numbers
        public string blue = "blue";
        public string drkblue = "darkblue";
        public string cyan = "cyan";
        public string drkcyan = "darkcyan";
        public string gray = "gray";
        public string drkGray = "darkgray";
        public string grn = "green";
        public string drkGrn = "darkgreen";
        public string mgnta = "magenta";
        public string drkmgnta = "darkmagenta";
        public string red = "red";
        public string drkRed = "darkred";
        public string ylw = "yellow";
        public string drkYlw = "darkyellow";
        public string wht = "white";
        public string blk = "black";

        public string[] _zero = { @" _____ ", @"|     |", @"|  |  |", @"|  |  |", @"|  |  |", @"|_____|" };
        public string[] __one = { @"     _ ", @"    | |", @"    | |", @"    | |", @"    | |", @"    |_|" };
        public string[] __two = { @" _____ ", @"| __  |", @"|/ / / ", @"  / /  ", @" / /_/|", @"|_____|" };
        public string[] three = { @" _____ ", @"|___  |", @"   _| |", @"  |_  |", @" ___| |", @"|_____|" };
        public string[] _four = { @" _   _ ", @"| | | |", @"| |_| |", @"|___  |", @"    | |", @"    |_|" };
        public string[] _five = { @" _____ ", @"|  ___|", @"| |___ ", @"|___  |", @" ___| |", @"|_____|" };
        public string[] __six = { @" _____ ", @"|  ___|", @"| |___ ", @"|  _  |", @"| |_| |", @"|_____|" };
        public string[] seven = { @" _____ ", @"|  _  |", @"|_| | |", @"    | |", @"    | |", @"    |_|" };
        public string[] eight = { @" _____ ", @"|     |", @"|  |  |", @"|     |", @"|  |  |", @"|_____|" };
        public string[] _nine = { @" _____ ", @"|  _  |", @"| |_| |", @"|___  |", @" ___| |", @"|_____|" };
        public string[] colon = { @"       ", @"   _   ", @"  |_|  ", @"   _   ", @"  |_|  ", @"       " };
        public string[] priod = { @"       ", @"       ", @"       ", @"       ", @"   _   ", @"  |_|  " };
        public string[] ____a = { @" _____ ", @"|  _  |", @"| |_| |", @"|  _  |", @"| | | |", @"|_| |_|" };
        public string[] ____p = { @" _____ ", @"|  _  |", @"| |_| |", @"|  ___|", @"| |    ", @"|_|    " };
        public string[] ____m = { @" _   _ ", @"| \_/ |", @"|     |", @"|     |", @"| | | |", @"|_|_|_|" };
        public string[] space = { @"       ", @"       ", @"       ", @"       ", @"       ", @"       " };
        /// LINE FORMATTING
        public string br = "\n\r ";
        #endregion color vars and numbers
        #region utils
        public void rest(int time)
        {
            Thread.Sleep(time);
        }
        public void clear()
        {
            Console.Clear();
        }
        #endregion utils
        #region write Module
        public void write(string input, string color)
        {
            ///RESET BACKGROUND TO BLACK IF BLACK FOREGROUND IS CHOSEN AT ANY POINT
            Console.BackgroundColor = ConsoleColor.Black;
            if (color != null)
            {
                color = color.ToLower();
            }
            pickColor(color);
            Console.Write(input);
        }
        #endregion write Module
        #region read modules
        public ConsoleKeyInfo rk(string _input, string colorOUT, string colorIN)
        {
            ///RESET BACKGROUND TO BLACK IF BLACK FOREGROUND IS CHOSEN AT ANY POINT
            //Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKeyInfo returnData;
            if (colorOUT != null)
            {
                colorIN = colorIN.ToLower();
            }
            pickColor(colorOUT);
            Console.Write(_input);
            if (colorIN != null)
            {
                colorIN = colorIN.ToLower();
            }
            pickColor(colorIN);
            returnData = Console.ReadKey();
            if (returnData.Key == ConsoleKey.LeftArrow || returnData.Key == ConsoleKey.RightArrow) { return returnData; }
            else
            {
                rest(500);
                return returnData;
            }
        }
        #endregion read modules
        #region Color Module
        public void pickColor(string color)
        {

            switch (color)
            {
                ///NORMAL COLORS
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                ///DARK COLORS
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkmagenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                ///DEFAULT COLOR
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }
        #endregion Color Module
    }
}
