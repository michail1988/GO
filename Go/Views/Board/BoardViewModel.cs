using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Go.Algorithms.Rules;
using Go.Basics;
using Go.Infrastructure.App;
using Go.ViewModels;
using Microsoft.Practices.Prism.Commands;

namespace Go.Views.Board
{
    public class BoardViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<FieldViewModel> board;

        // TODO !
        public GameController gameController;
        private DelegateCommand randomAlgorithm;

        #endregion

        #region Constructors

        public BoardViewModel()
        {
            // TODO move upper
            this.gameController = AppManager.GameController;

            this.CreateBoard();

            this.gameController.RefreshViewEvent += this.OnRefreshEvent;
            this.gameController.NewGameEvent += this.OnNewGameEvent;

            // TODO temp
            this.randomAlgorithm = new DelegateCommand(this.RandomAlgorithmAction);
        }

        #endregion

        #region Properties
        
        public ObservableCollection<FieldViewModel> BoardFields
        {
            get
            {
                return this.board;
            }
        }

        #endregion

        #region Methods

        public void OnRefreshEvent(object oSender, EventArgs oEventArgs)
        {
            this.RefreshFields();
        }

        private void RefreshFields()
        {
            foreach (var view in this.BoardFields)
            {
                view.Refresh();
            }
        }

        public void OnNewGameEvent(object sender, EventArgs args)
        {
            this.gameController = AppManager.GameController;
            this.CreateBoard();
        }

        private void CreateBoard()
        {
            if (this.board != null)
            {
                this.board.Clear();
            }

            this.board = BoardFactory.CreateBoardFromContext(19 * 19, this.gameController);
            this.RefreshFields();

            this.RaisePropertyChanged(() => this.BoardFields);
        }

        #endregion

        public ICommand RandomAlgorithm
        {
            get
            {
                return this.randomAlgorithm;
            }
        }

        public void RandomAlgorithmAction()
        {
        }
    }
}
