using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;

namespace Go.Basics.Common
{
    public class Field : ICloneable
    {
        #region Fields

        private States fieldState;

        /// <summary>
        /// Index of the field in the game table board.
        /// </summary>
        private int index;

        /// <summary>
        /// An amount of the empty fields arround.
        /// TODO place in the chain
        /// </summary>
        private int surroundingEmptySquares;

        /// <summary>
        /// Holds reference to chain, which filled pawn
        /// is connected.
        /// It can't be pawn without chain.
        /// </summary>
        private Chain chain;

        #endregion

        #region Constructors

        public Field(States fieldState, int index)
        {
            this.fieldState = fieldState;
            this.index = index;
        }

        #endregion

        #region Properties

        public States FieldState
        {
            get
            {
                return this.fieldState;
            }

            set
            {
                this.fieldState = value;
            }
        }

        public int GetIndex()
        {
            return this.index;
        }

        public int SurroundingEmptySquares
        {
            get
            {
                return this.surroundingEmptySquares;
            }

            set
            {
                this.surroundingEmptySquares = value;
            }
        }

        public bool IsChained
        {
            get
            {
                return chain != null && chain.Count > 1;
            }
        }

        public Chain Chain
        {
            get
            {
                return this.chain;
            }

            set
            {
                this.chain = value;
            }
        }

        #endregion

        #region Methods

        public void ConnectToChain(Chain chain)
        {
            this.chain = chain;
        }

        #endregion

        public int EnemiesCounter { get; set; }


        public object Clone()
        {
            var clone = new Field(this.FieldState, this.index);
            clone.SurroundingEmptySquares = this.SurroundingEmptySquares;
            return clone;
        }
    }
}
