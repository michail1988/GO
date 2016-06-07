using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Infrastructure.Settings;

namespace Go.Basics.Common
{
    public class PositionContext
    {
        private States move;

        private int dimension = (int) Settings.BoardSize;

        /// <summary>
        /// The constructor creates the initial empty context for a new game.
        /// 
        /// Should be executed only in two places:
        /// - gameContext - creates position for new game
        /// - PositionContextFactory - copy the position for the algorithms and sets all the variables
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="chains"></param>
        /// <param name="move"></param>
        public PositionContext(ObservableCollection<Field> fields, List<Chain> chains, States move)
        {
            Fields = fields;
            Chains = chains;
            Move = move;
            WhitePoints = 0;
            BlackPoints = 0;
        }

        public Field GetField(int field)
        {
            return this.Fields[field];
        }

        public Field GetLeft(int field)
        {
            if (field % this.dimension == 0)
            {
                return null;
            }

            int leftPosition = field - 1;

            if (leftPosition >= 0)
            {
                return Fields[leftPosition];
            }

            return null;
        }

        public Field GetRight(int field)
        {
            if ((field + 1) % this.dimension == 0)
            {
                return null;
            }

            int rightPosition = field + 1;

            if (rightPosition < this.Fields.Count - 1)
            {
                return Fields[rightPosition];
            }

            return null;
        }

        public Field GetLower(int field)
        {
            int lowerPosition = field + this.dimension;

            if (lowerPosition < this.Fields.Count - 1)
            {
                return Fields[lowerPosition];
            }

            return null;
        }

        public Field GetUpper(int field)
        {
            int upperPosition = field - this.dimension;

            if (upperPosition >= 0)
            {
                return Fields[upperPosition];
            }

            return null;
        }
        
        /// <summary>
        /// Indicates who has the turn.
        /// </summary>
        public States Move
        {
            get
            {
                return this.move;
            }

            set
            {
                this.move = value;
            }
        }

        public ObservableCollection<Field> Fields;
        public List<Chain> Chains;

        public int WhitePoints;

        public int BlackPoints;

        /// <summary>
        /// TODO: Move to the controller
        /// </summary>
        public void NextTurn()
        {
            if (this.Move == States.White)
            {
                this.Move = States.Black;
            }
            else
            {
                this.Move = States.White;
            }
        }
    }
}
