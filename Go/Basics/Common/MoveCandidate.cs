using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Basics.Common
{
    public class MoveCandidate
    {
        private double evaluation;

        private int fieldToMove;

        private PositionContext positionContext;

        public MoveCandidate(int fieldToMove, PositionContext positionContext)
        {
            this.FieldToMove = fieldToMove;
            this.PositionContext = positionContext;
        }

        public double Evaluation
        {
            get { return evaluation; }
            set { evaluation = value; }
        }

        public int FieldToMove
        {
            get { return fieldToMove; }
            set { fieldToMove = value; }
        }

        public PositionContext PositionContext
        {
            get { return positionContext; }
            set { positionContext = value; }
        }
    }
}
