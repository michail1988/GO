using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Basics.Common;
using Microsoft.Build.Utilities;

namespace Go.Infrastructure.Core
{

    public static class Logger /* :  Microsoft.Build.Utilities.Logger* */
    {

        public static void Log(String message)
        {
            System.Console.WriteLine(message);
        }

        public static void LogDepth(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Log(" - ");
            }
        }

        public static void LogMove(PositionContext position)
        {
            if (position.Move == States.White)
                Log("Białe");
            else
                Log("Czarne");
        }
    }
     
}
