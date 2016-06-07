using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Algorithms;
using Go.Basics.Common;
using Go.Infrastructure.Settings;

namespace Go.Basics.Helpers
{
    /// <summary>
    /// http://notatnik.mekk.waw.pl/archives/193-Go.html
    /// </summary>
    public static class PositionHelper
    {
        #region Fields

        public static int BigBoardDimension = 19;
        public static int MiddleBoardDimension = 13;
        public static int SmallBoardDimension = 10;

        #endregion

        #region Methods

        /// <summary>
        /// Computes the position in the list.
        ///    A B C D E F G H I J K L M N O P Q R S
        /// 19 0 1 2 3 4 5 6 7 8 9 ...
        /// 18
        /// 17
        /// 16
        /// 15
        /// .
        /// .
        /// .
        /// 1
        /// 
        /// Depends of the board dimension.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The number of the item on the list.</returns>
        public static int ListPosition(char x, int y)
        {
            // TODO casting necessarily?
            int dimension = (int) Settings.BoardSize;
            int xCount = (dimension - y) * dimension;
            return decodeLetter(x) + xCount;
        }

        /// <summary>
        /// Encodes list index to square coordinates.
        /// </summary>
        /// <param name="listPosition">Position in the list.</param>
        /// <param name="dimension">Board dimension.</param>
        /// <returns>"A1" descripiton.</returns>
        public static string MoveDescription(int listPosition)
        {
            int dimension = (int) Settings.BoardSize;
            string letter = encodeLetter(listPosition % dimension);
            int y = dimension - (listPosition / dimension);

            return letter + y.ToString();
        }

        internal static ObservableCollection<Field> CreateFieldsList(string position = null)
        {
            int boardSize = (int) Settings.BoardSize;
            int fieldsCounter = boardSize * boardSize;

            if (position == null)
            {
                var fields = new ObservableCollection<Field>();

                for (int i = 0; i < fieldsCounter; i++)
                {
                    fields.Add(new Field(States.Empty, fields.Count));
                }

                return fields;
            }

            return DecodePositionStringToFields(position);
        }

        // TODO STRING BUILDER - performance importance
        public static String EncodeStringPosition(GameContext gameContext)
        {
            String positionString = "";
            var fields = gameContext.Fields;

            int numEmpty = 0;
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].FieldState.Equals(States.White))
                {
                    if (numEmpty != 0)
                    {
                        positionString += numEmpty.ToString();
                        numEmpty = 0;
                    }

                    positionString += 'w';
                }

                else
                {
                    if (fields[i].FieldState.Equals(States.Black))
                    {
                        if (numEmpty != 0)
                        {
                            positionString += numEmpty.ToString();
                            numEmpty = 0;
                        }

                        positionString += 'b';
                    }

                    else
                    {
                        numEmpty++;

                        if (i + 1 == fields.Count)
                        {
                            positionString += numEmpty.ToString();
                        }
                    }
                }
            }

            return positionString;
        }

        #endregion

        #region Private Methods

        private static int decodeLetter(char bigLetter)
        {
            var letter = (int) bigLetter;

            // TODO Exception
            if (letter == null)
            {
                throw new Exception("True letter should be char convertible");
            }

            // big character
            if (letter <= 90)
            {
                return letter - 65;
            }

            // small character
            return letter - 97;
        }

        private static string encodeLetter(int position)
        {
            char ch = Convert.ToChar(position + 65);
            return ch.ToString();
        }
        
        /// <summary>
        /// TODO CHECK the constructor index .count
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static ObservableCollection<Field> DecodePositionStringToFields(string position)
        {
            var fields = new ObservableCollection<Field>();

            double num = -1;

            for (int i = 0; i < position.Length; i++)
            {
                // conversion

                double ch = Char.GetNumericValue(position[i]); // position[i] - 0;
                if (ch >= 0 && ch < 10)
                {
                    if (num == -1)
                    {
                        num = ch;
                    }
                    else
                    {
                        num = 10 * num + ch;
                    }

                    if (i + 1 == position.Length)
                    {
                        for (int j = 0; j < num; j++)
                        {
                            fields.Add(new Field(States.Empty, fields.Count));
                        }
                    }
                }
                else
                {
                    if (num != -1)
                    {
                        for (int j = 0; j < num; j++)
                        {
                            fields.Add(new Field(States.Empty, fields.Count));
                        }

                        num = -1;
                    }
                }

                if (position[i].Equals('b'))
                {
                    fields.Add(new Field(States.Black, fields.Count));
                }

                if (position[i].Equals('w'))
                {
                    fields.Add(new Field(States.White, fields.Count));
                }
            }

            return fields;
        }        

        public static bool AreEnemies(Field field, Field neighbour)
        {
            if (neighbour == null || field == null)
            {
                return false;
            }

            if (field.FieldState == States.Empty || neighbour.FieldState == States.Empty)
            {
                return false;
            }

            if (field.FieldState == neighbour.FieldState)
            {
                return false;
            }

            return true;
        }

        public static bool AreFriends(Field field, Field neighbour)
        {
            if (neighbour == null || field == null)
            {
                return false;
            }

            if (field.FieldState == States.Empty || neighbour.FieldState == States.Empty)
            {
                return false;
            }

            if (field.FieldState != neighbour.FieldState)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
