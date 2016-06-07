using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Infrastructure.Core.Menu;
using Go.ViewModels;
using Go.Views.Board;

namespace Go.Views
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private BoardViewModel boardViewModel;
        
        private InfoViewModel infoViewModel;

        private MenuManager menuManager;

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            this.menuManager = new MenuManager();
            this.boardViewModel = new BoardViewModel();

            // TODO 
            this.infoViewModel = new InfoViewModel(this.boardViewModel.gameController);
        }

        #endregion

        #region Properties

        public MenuManager Menu
        {
            get
            {
                return this.menuManager;
            }
        }
        
        public BoardViewModel BoardViewModel
        {
            get
            {
                return this.boardViewModel;
            }
        }

        public InfoViewModel InfoViewModel
        {
            get
            {
                return this.infoViewModel;
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
