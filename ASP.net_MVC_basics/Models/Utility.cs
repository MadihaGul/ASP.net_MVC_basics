using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Models
{
    public class Utility
    {
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
    }
}
