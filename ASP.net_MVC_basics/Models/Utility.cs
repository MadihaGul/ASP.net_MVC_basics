using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class Utility
    {
        
        public static string gameStart()
        {
            return $"Got a new secret number. Guess!!!";
        }

        public static uint generateRandomNum()
        {
            Random rnd = new Random();
            return Convert.ToUInt32( rnd.Next(1,101));
        }
        public static string IsGuessRight(uint secretNum, uint guess)
        {
            string msg = "";
                
                    if (secretNum == guess)
                    {
                        msg= $"Congratulations! You won."; 
                        
                    }
                    else
                    {
                            if (guess < secretNum)
                            { msg = $"Sorry! Try again (Hint: Guessed number is too little)"; }
                            else
                            { msg = $"Sorry! Try again (Hint: Guessed number is too high)"; }
                    }
            return msg;

        }

        //public static string IsGuessRight(uint secretNum, uint guess)
        //{
        //    if (secretNum==guess)
        //    {
        //        return $"Congratulations! You Win.";
        //    }
        //    else
        //    { return $"Sorry! you guessed wrong. Try again"; }
            
        //}


        public static string msg()
        {
                return $"Please enter temperature in farenhiet";
        }
        public  static string chkFever(double temp)
        {
            if (temp > 99)
                return $"Body temperature is higher than usual. It indicates fever"; 
            else if (temp < 97)
                return $"Body temperature is lower than usual. It indicates hypothermia"; 
            else
                return $"Body temperature is normal";


        }

        // Defines ordnings tal
        public static string DefineOrdningstal(int n)
        {
            string ordtal = "";
            if (n == 1 ) { ordtal = n + "st"; }
            else if ( n == 2) { ordtal = n + "nd"; }
            else if (n == 3) { ordtal = n + "rd"; }
            else { ordtal = n + "th"; }
            return ordtal;
        }

        public static bool CheckUint(string val1)
        {
            if (val1 == "0")
            { return false; }
            else
            {
                if (uint.TryParse(val1, out uint intval))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

    }
}
