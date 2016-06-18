using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Basics;
using Go.Views.Board;
using Go.Infrastructure.Settings;

namespace Go.Algorithms.Rules
{
    public static class BoardFactory
    {
        /// <summary>
        /// Creates fields view models list.
        /// </summary>
        /// <param name="number">The number of fields</param>
        /// <returns>Fields view models.</returns>
        public static ObservableCollection<FieldViewModel> CreateFields(int number, GameController gameController)
        {
            var board = new ObservableCollection<FieldViewModel>();

            for (int i = 0; i < number; i++)
            {
                board.Add(new FieldViewModel(gameController, i));
            }

            return board;
        }

        public static ObservableCollection<CoordinateViewModel> CreateXCoordinates()
        {
            int number = GetSquareCount();
            

            var coordinates = new ObservableCollection<CoordinateViewModel>();
            for (int i = 0; i < number; i++)
            {
                coordinates.Add(new CoordinateViewModel(Basics.Helpers.PositionHelper.EncodeLetter(i)));
            }

            return coordinates;
        }

        public static ObservableCollection<CoordinateViewModel> CreateYCoordinates()
        {
            int number = GetSquareCount();

            var coordinates = new ObservableCollection<CoordinateViewModel>();
            for (int i = 0; i < number; i++)
            {
                coordinates.Add(new CoordinateViewModel(Convert.ToString(number - i)));
            }

            return coordinates;
        }

        public static ObservableCollection<FieldViewModel> CreateBoardFromContext(GameController gameController)
        {
            int count = GetSquareCount();

            var board = new ObservableCollection<FieldViewModel>();

            for (int i = 0; i < count * count; i++)
            {
                if (gameController.GameContext.Fields == null || i >= gameController.GameContext.Fields.Count)
                {
                    break;
                }

                board.Add(new FieldViewModel(gameController, i, gameController.GameContext.Fields[i].FieldState));
            }

            return board;
        }

        private static int GetSquareCount()
        {
            switch (Settings.BoardSize)
            {
                case BoardSizes.Board_10_10:
                    return 10;
                case BoardSizes.Board_19_19:

                    return 19;
            }

            //TODO Exception!
            return -1;
        }
    }
}
