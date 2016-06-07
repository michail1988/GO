using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Go.Basics.Common;
using Microsoft.Practices.Prism.Commands;

namespace Go.Basics.Rules
{
    /// <summary>
    /// Describes the move.
    /// Defines the time, coordinates.
    /// </summary>
    public class MoveDescription
    {
        #region Fields

        private string square;

        private TimeSpan moveTime;

        private string positionString;

        private ICommand changePositionCommand;

        #endregion

        #region Constructors

        public MoveDescription(string square, TimeSpan moveTime, string positionString)
        {
            this.Square = square;
            this.moveTime = moveTime;
            this.positionString = positionString;

            this.changePositionCommand = new DelegateCommand(this.ChangePositionAction);
            
        }

        #endregion

        #region Properties

        public string Square
        {
            get
            {
                return this.square;
            }

            set
            {
                this.square = value;
            }
        }

        public string MoveTime
        {
            get
            {
                return string.Format("{0}:{1}.{2}", this.moveTime.Minutes, this.moveTime.Seconds, this.moveTime.Milliseconds/100, CultureInfo.InvariantCulture);
            }
        }

        #endregion
        
        #region Methods
        #endregion

        public ICommand ChangePositionCommand
        {
            get
            {
                return this.changePositionCommand;
            }
        }

        private void ChangePositionAction()
        {
        }
    }
}
