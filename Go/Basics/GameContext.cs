using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Algorithms.Rules;
using Go.Basics.Common;
using Go.Basics.Helpers;
using Go.Basics.Rules;
using Go.Infrastructure.Settings;

namespace Go.Algorithms
{
    public class GameContext : PositionContext
    {
        #region Fields

        private int dimension;

        private String position;

        private ObservableCollection<MoveDescription> whiteMoves;

        private ObservableCollection<MoveDescription> blackMoves;

        private DateTime startTime;

        private DateTime lastMoveTime;
               
        #endregion

        #region Constructors

        /// <summary>
        /// first move makes black player
        /// </summary>
        /// <param name="position"></param>
        public GameContext(String position = null)
            : base(PositionHelper.CreateFieldsList(position), new List<Chain>(), States.Black)
        {
            
            this.position = position;
            //base(PositionHelper.CreateFieldsList(this.position), new List<Chain>());

            //this.position = "0w1b10w1b1w3bb5w0b";

            this.Fields = PositionHelper.CreateFieldsList(this.position);

            this.blackMoves = new ObservableCollection<MoveDescription>();
            this.whiteMoves = new ObservableCollection<MoveDescription>();

            this.startTime = DateTime.Now;
            this.lastMoveTime = this.startTime;
        }

        #endregion

        #region Properties

        public ObservableCollection<MoveDescription> WhiteMoves
        {
            get
            {
                return this.whiteMoves;
            }
        }

        public ObservableCollection<MoveDescription> BlackMoves
        {
            get
            {
                return this.blackMoves;
            }
        }
        
        #endregion

        #region Method

        public void ActualizeContextAfterMove(int index)
        {
            if (this.Move == States.White)
            {
                this.WhiteMoves.Add(this.DefineMoveDescription(index));
            }
            else
            {
                this.BlackMoves.Add(this.DefineMoveDescription(index));
            }
        }

        public void EmptyField(int index)
        {
            this.Fields[index].FieldState = States.Empty;
        }

        #endregion

        #region Private fields

        /// <summary>
        /// Creates description of the move.
        /// Notices the time and coordinates.
        /// </summary>
        /// <param name="index">The field table index.</param>
        /// <returns>The move description.</returns>
        private MoveDescription DefineMoveDescription(int index)
        {
            // TODO move it to the move factory
            // it should be possible to manage between 
            // different gamecontext ? during computation
            // without changes in the viewmodels
            // or create special context
            var time = TimeHelper.GetMoveTime(this.lastMoveTime);
            this.lastMoveTime = DateTime.Now;

            return new MoveDescription(PositionHelper.MoveDescription(index), time, PositionHelper.EncodeStringPosition(this));
        }

        #endregion
    }
}
