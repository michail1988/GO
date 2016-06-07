using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Basics.Common;

namespace Go.Basics.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValid(PositionContext position, int index)
        {
            Field field = position.GetField(index);
            if (field.SurroundingEmptySquares != 0)
            {
                if ((position.GetLeft(index) != null && PositionHelper.AreEnemies(field, position.GetLeft(index)))
                    &&
                    (position.GetRight(index) != null && PositionHelper.AreEnemies(field, position.GetRight(index)))
                    &&
                    (position.GetLower(index) != null && PositionHelper.AreEnemies(field, position.GetLower(index)))
                    &&
                    (position.GetUpper(index) != null && PositionHelper.AreEnemies(field, position.GetUpper(index))))
                {
                    // TODO
                    // if we are putting the stone between all the enemies pawn
                    // there must be beating move
                }
            }

            return true;
        }
    }
}
