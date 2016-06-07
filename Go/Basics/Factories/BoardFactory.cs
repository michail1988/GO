using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Basics;
using Go.Views.Board;

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

        public static ObservableCollection<FieldViewModel> CreateBoardFromContext(int number, GameController gameController)
        {
            var board = new ObservableCollection<FieldViewModel>();

            for (int i = 0; i < number; i++)
            {
                if (gameController.GameContext.Fields == null || i >= gameController.GameContext.Fields.Count)
                {
                    break;
                }

                board.Add(new FieldViewModel(gameController, i, gameController.GameContext.Fields[i].FieldState));
            }

            return board;
        }
    }
}
