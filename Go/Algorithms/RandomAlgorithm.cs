using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Infrastructure.Settings;
using Go.Log;
using Go.Basics.Common;

namespace Go.Algorithms
{
    public class RandomAlgorithm : Algorithm
    {
        #region Fields

        private Random random;

        /// <summary>
        /// The position's evaluation.
        /// </summary>
        private Double evaluation;

        #endregion

        #region Constructors

        public RandomAlgorithm(GameContext context)
            : base(context)
        {
            this.random = new Random();
            this.evaluation = 0.0;
        }

        #endregion


        #region Methods

        public override MoveCandidate Play()
        {
            int dimension = (int) Settings.BoardSize;
            // TODO
            // very, very stupid clause
            while (true)
            {
                int fieldIndex = this.randomNumber(0, dimension * dimension - 1);

                if (this.gameContext.GetField(fieldIndex).FieldState.Equals(States.Empty))
                {

                    MoveInfo logInfo = new MoveInfo("Wylosowalem taki ruch=" + fieldIndex);

                    this.gameContext.Info = logInfo;

                    MoveCandidate move = new MoveCandidate(fieldIndex);

                    return move;
                }
            }
            
            
        }

        #endregion

        #region Private methods

        private int randomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }

        #endregion
    }
}
