using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uart_AP
{
   public class FIR_param
    {
        public static int[] pi_3_18p = new int[] { -141, -194, 416, 1483, 1146, -1566, -3837, -2120, 2120, 3837, 1566, -1146, -1483, -416, 194, 141, 16, -16 };
        public static int[] pi_18p = new int[] { 69 ,-190 ,410 ,-736, 1144 ,-1569 ,1928 ,-2132 ,2132 ,-1928 ,1569 ,-1144 ,736, -410 ,190 ,-69 ,15 , -15};

        public static int[] pi_3_6p = new int[] {1365 ,683, -683 ,-1365 , -683, 683 };
        public static int[] pi_6p = new int[] { 431,-697 ,920 ,-920 ,697, -431 };
    }
}
