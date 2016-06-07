using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Infrastructure.Helpers
{
    public static class LayoutManager
    {
        #region Fields

        private static String bitmapsPath = "/Go;component/Resources/Bitmaps/";

        #endregion

        #region Properties

        public static String EmptyField = bitmapsPath + "Field.png";

        public static String BlackField = bitmapsPath + "Black.png";

        public static String WhiteField = bitmapsPath + "White.png";

        #endregion
    }
}
