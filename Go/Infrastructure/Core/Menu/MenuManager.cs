using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Go.Infrastructure.Core.IO;
using Go.ViewModels;
using Go.Infrastructure.App;
using Go.Infrastructure.Settings;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using Go.Algorithms.Rules;
using Go.Algorithms;

namespace Go.Infrastructure.Core.Menu
{
    public class MenuManager : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Switches to the human vs mashine mode.
        /// </summary>
        private DelegateCommand humanVsMashine;

        /// <summary>
        /// Switches to the 2 human's game mode.
        /// </summary>
        private DelegateCommand humanVsHuman;

        /// <summary>
        /// Play with the random algorithm.
        /// </summary>
        private DelegateCommand randomAlgorithm;

        /// <summary>
        /// Creates new game.
        /// </summary>
        private DelegateCommand newGame;

        /// <summary>
        /// Opens a game from file.
        /// </summary>
        private DelegateCommand openGame;

        /// <summary>
        /// Saves the game to file.
        /// </summary>
        private DelegateCommand saveGame;

        /// <summary>
        /// Closes application.
        /// </summary>
        private DelegateCommand exitCommand;

        /// <summary>
        /// Changes board size.
        /// </summary>
        private DelegateCommand changeBoardSizeCommand;

        /// <summary>
        /// Indicates whether player vs mashine mode is enabled.
        /// </summary>
        private bool humanVsMashineChecked;

        /// <summary>
        /// Indicates whether player vs player mode is enabled.
        /// </summary>
        private bool humanVsHumanChecked;

        /// <summary>
        /// Indicates whether random algorithm is checked
        /// </summary>
        private bool randomAlgorithmChecked;

        /// <summary>
        /// Indicates whether min max algorithm is checked
        /// </summary>
        private bool minMaxAlgorithmChecked;

        /// <summary>
        /// Indicates whether simple beating algorithm is checked
        /// </summary>
        private bool simpleBeatingAlgorithmChecked;

        #endregion

        #region Constructors

        public MenuManager()
        {
            // File
            this.newGame = new DelegateCommand(this.NewGameAction);
            this.openGame = new DelegateCommand(this.OpenGameAction);
            this.saveGame = new DelegateCommand(this.SaveGameAction);
            this.exitCommand = new DelegateCommand(this.ExitAction);

            // Game items
            this.humanVsMashine = new DelegateCommand(this.HumanVsMashineAction);
            this.humanVsHuman = new DelegateCommand(this.HumanVsHumanAction);

            // Algorithms
            this.randomAlgorithm = new DelegateCommand(this.RandomAlgorithmAction);

            // Options
            this.changeBoardSizeCommand = new DelegateCommand(this.ChangeBoardSizeAction);

            //Default settings
            this.HumanVsHumanChecked = true;
            this.MinMaxAlgorithmChecked = true;
        }

        #endregion

        #region Commands

        public ICommand HumanVsHuman
        {
            get
            {
                return this.humanVsHuman;
            }
        }

        public ICommand HumanVsMashine
        {
            get
            {
                return this.humanVsMashine;
            }
        }

        public ICommand RandomAlgorithm
        {
            get
            {
                return this.randomAlgorithm;
            }
        }

        public ICommand NewGame
        {
            get
            {
                return this.newGame;
            }
        }

        public ICommand OpenGame
        {
            get
            {
                return this.openGame;
            }
        }

        public ICommand SaveGame
        {
            get
            {
                return this.saveGame;
            }
        }

        public ICommand Exit
        {
            get
            {
                return this.exitCommand;
            }
        }

        public ICommand ChangeBoardSize
        {
            get
            {
                return this.changeBoardSizeCommand;
            }
        }

        #endregion

        #region Actions

        public void NewGameAction()
        {
            GameFactory.NewGame();
        }

        public void OpenGameAction()
        {
        }

        public void SaveGameAction()
        {
   
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Xml file|*.xml|Go File|*.go";
            saveDialog.Title = "Save the game";
            saveDialog.ShowDialog();

            // TODO name is microsoft reserved
            FileWriter writer = new FileWriter(saveDialog.OpenFile() as FileStream);
        }

        public void ExitAction()
        {
            Application.Current.MainWindow.Close();
        }

        public void HumanVsMashineAction()
        {
        }

        public void HumanVsHumanAction()
        {
        }

        public void RandomAlgorithmAction()
        {
        }

        public void ChangeBoardSizeAction()
        {
        }

        #endregion

        #region Properties

        public bool HumanVsHumanChecked
        {
            get
            {
                return Settings.Settings.PlayingWithComputer == false;
            }

            set
            {
                Settings.Settings.PlayingWithComputer = !value;

                this.RaisePropertyChanged(() => this.HumanVsMashineChecked);
            }
        }

        public bool HumanVsMashineChecked
        {
            get
            {
                return Settings.Settings.PlayingWithComputer;
            }

            set
            {
                Settings.Settings.PlayingWithComputer = value;

                this.RaisePropertyChanged(() => this.HumanVsMashineChecked);
                this.RaisePropertyChanged(() => this.HumanVsHumanChecked);
            }
        }

        public bool RandomAlgorithmChecked
        {
            get
            {
                return this.randomAlgorithmChecked;
            }

            set
            {
                this.randomAlgorithmChecked = value;
                this.minMaxAlgorithmChecked = !value;
                this.simpleBeatingAlgorithmChecked = !value;

                if (value == true)
                {
                    Settings.Settings.Algorithm = AlgorithmEnum.Random;
                    AppManager.GameController.RefreshAlgorithm();
                }

                this.RaisePropertyChanged(() => this.SimpleBeatingAlgorithmChecked);
                this.RaisePropertyChanged(() => this.MinMaxAlgorithmChecked);
                this.RaisePropertyChanged(() => this.RandomAlgorithmChecked);
            }
        }

        public bool MinMaxAlgorithmChecked
        {
            get
            {
                return this.minMaxAlgorithmChecked;
            }

            set
            {
                this.minMaxAlgorithmChecked = value;
                this.randomAlgorithmChecked = !value;
                this.simpleBeatingAlgorithmChecked = !value;

                if (value == true)
                {
                    Settings.Settings.Algorithm = AlgorithmEnum.MinMax;
                    AppManager.GameController.RefreshAlgorithm();
                }

                this.RaisePropertyChanged(() => this.SimpleBeatingAlgorithmChecked);
                this.RaisePropertyChanged(() => this.MinMaxAlgorithmChecked);
                this.RaisePropertyChanged(() => this.RandomAlgorithmChecked);
            }
        }

        public bool SimpleBeatingAlgorithmChecked
        {
            get
            {
                return this.simpleBeatingAlgorithmChecked;
            }

            set
            {
                this.simpleBeatingAlgorithmChecked = value;
                this.minMaxAlgorithmChecked = !value;
                this.randomAlgorithmChecked = !value;

                if (value == true)
                {
                    Settings.Settings.Algorithm = AlgorithmEnum.SimpleBeating;
                    AppManager.GameController.RefreshAlgorithm();
                }

                this.RaisePropertyChanged(() => this.SimpleBeatingAlgorithmChecked);
                this.RaisePropertyChanged(() => this.MinMaxAlgorithmChecked);
                this.RaisePropertyChanged(() => this.RandomAlgorithmChecked);
            }
        }

        public bool IsBoard_19_19
        {
            get
            {
                return Settings.Settings.BoardSize == BoardSizes.Board_19_19;
            }

            set
            {
                // TODO confirmation
                // new game

                Settings.Settings.BoardSize = BoardSizes.Board_19_19;
                this.RaisePropertyChanged(() => this.IsBoard_10_10);
                this.NewGameAction();
            }
        }

        public bool IsBoard_10_10
        {
            get
            {
                return Settings.Settings.BoardSize == BoardSizes.Board_10_10;
            }

            set
            {
                // TODO confirmation
                // new game

                Settings.Settings.BoardSize = BoardSizes.Board_10_10;
                this.RaisePropertyChanged(() => this.IsBoard_19_19);
                this.NewGameAction();
            }
        }

        #endregion
    }
}
