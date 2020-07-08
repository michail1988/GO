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

        public MoveCandidate(int fieldToMove)
        {
            this.FieldToMove = fieldToMove;
        }

        public MoveCandidate(int fieldToMove, double evaluation)
        {
            this.FieldToMove = fieldToMove;
            this.Evaluation = evaluation;
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

        //TODO Michal to nie jest na razie wykorzystywane
        public PositionContext PositionContext
        {
            get { return positionContext; }
            set { positionContext = value; }
        }
    }
}
