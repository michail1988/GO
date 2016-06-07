using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Go.Basics;
using Go.Basics.Rules;
using Go.Helpers;
using Go.ViewModels;

namespace Go.Views
{
    public class InfoViewModel : BaseViewModel
    {
        #region Fields

        private GameController controller;

        private ICommand changePositionCommand;

        #endregion

        #region Constructors

        public InfoViewModel(GameController controller)
        {
            this.controller = controller;
            this.controller.RefreshViewEvent += this.OnRefreshEvent;
            this.controller.NewGameEvent += this.OnNewGameEvent;

            this.changePositionCommand = new DelegateCommand(this.ChangePositionAction);
            SelectedItem = 10;
        }

        #endregion

        #region Properties

        public String Score
        {
            get
            {
                return this.controller.GameContext.WhitePoints + " - " + this.controller.GameContext.BlackPoints;
            }
        }

        public ObservableCollection<MoveDescription> WhiteMoves
        {
            get
            {
                return this.controller.GameContext.WhiteMoves;
            }
        }

        public ObservableCollection<MoveDescription> BlackMoves
        {
            get
            {
                return this.controller.GameContext.BlackMoves;
            }
        }

        public String Evaluation
        {
            get
            {
                var eval = 0;// TODO place evaluation this.controller.GameContext.GetEvaluation();

                // favours white
                if (eval > 0)
                {
                    return String.Format(CultureInfo.InvariantCulture, "+ {0}", eval.ToString());
                }

                if (eval < 0)
                {
                    return String.Format(CultureInfo.InvariantCulture, "- {0}", eval.ToString());
                }

                return eval.ToString();
            }
        }

        #endregion

        #region Methods

        public void OnRefreshEvent(object oSender, EventArgs oEventArgs)
        {
            this.RaisePropertyChanged(() => this.Score);
            this.RaisePropertyChanged(() => this.Evaluation);
            this.RaisePropertyChanged(() => this.WhiteMoves);
            this.RaisePropertyChanged(() => this.BlackMoves);

        }

        public void OnNewGameEvent(object oSender, EventArgs oEventArgs)
        {
            this.RaisePropertyChanged(() => this.Score);
            this.RaisePropertyChanged(() => this.Evaluation);
            this.RaisePropertyChanged(() => this.WhiteMoves);
            this.RaisePropertyChanged(() => this.BlackMoves);

        }

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

        public int SelectedItem;
    }
}
