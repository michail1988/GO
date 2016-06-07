using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Basics.Helpers
{
    public static class TimeHelper
    {
        #region Methods
        
        internal static TimeSpan GetMoveTime(DateTime lastMoveTime)
        {
            var currentTime = DateTime.Now;

            var moveDuration = currentTime - lastMoveTime;

            return moveDuration;
        }

        #endregion
    }
}
