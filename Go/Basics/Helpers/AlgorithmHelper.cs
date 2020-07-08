using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Go.Basics.Common;
using Go.Infrastructure.Settings;

namespace Go.Basics.Helpers
{
    public static class AlgorithmHelper
    {

        public static Chain GetBiggestUnbeatenChain(PositionContext positionContext)
        {
            Chain biggest = null;
            int biggestSizeToSurround = 0;

            foreach (var chain in positionContext.Chains.Where(x => x.Color != positionContext.Move && !x.Beated))
            {
                if (chain.Count > biggestSizeToSurround)
                {
                    biggestSizeToSurround = chain.Count;
                    biggest = chain;
                }
            }

            return biggest;
        }

        public static int GetSomethingToBeat()
        {
            return 0;
        }
    }
}
