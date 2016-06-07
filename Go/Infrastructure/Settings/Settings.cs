using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithms;

namespace Go.Infrastructure.Settings
{
    public static class Settings
    {
        public static bool PlayingWithComputer = true;

        public static BoardSizes BoardSize = BoardSizes.Board_19_19;

        public static AlgorithmEnum Algorithm;
        public static int MaxDepth = 3;
    }
}
