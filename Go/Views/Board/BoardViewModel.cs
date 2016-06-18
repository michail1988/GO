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
using Go.Infrastructure.Settings;

namespace Go.Views.Board
{
    public class BoardViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<FieldViewModel> board;
        private ObservableCollection<CoordinateViewModel> xCoordinatesFields;
        private ObservableCollection<CoordinateViewModel> yCoordinatesFields;
        
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

        public ObservableCollection<CoordinateViewModel> XCoordinatesFields
        {
            get
            {
                return this.xCoordinatesFields;
            }
        }

        public ObservableCollection<CoordinateViewModel> YCoordinatesFields
        {
            get
            {
                return this.yCoordinatesFields;
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
            
            this.board = BoardFactory.CreateBoardFromContext(this.gameController);
            this.RefreshFields();

            this.RaisePropertyChanged(() => this.BoardFields);

            // TODO move to the BoardFactory
            this.xCoordinatesFields = BoardFactory.CreateXCoordinates();
            this.yCoordinatesFields = BoardFactory.CreateYCoordinates();

            this.RaisePropertyChanged(() => this.XCoordinatesFields);
            this.RaisePropertyChanged(() => this.YCoordinatesFields);
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
