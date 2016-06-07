using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Go.Algorithm.Rules;
using Go.Algorithms;
using Go.Basics;
using Go.Infrastructure.Helpers;
using Go.Infrastructure.Settings;
using Go.ViewModels;
using Microsoft.Practices.Prism.Commands;

namespace Go.Views.Board
{
    public class FieldViewModel : BaseViewModel
    {
        #region Fields

        private DelegateCommand clickCommand;

        private GameController gameController;

        private States fieldState;

        private int index;
                
        #endregion

        #region Constructors

        public FieldViewModel(GameController gameController, int index, States state = States.Empty)
        {
            this.gameController = gameController;
            this.index = index;

            this.fieldState = this.gameController.GameContext.Fields[index].FieldState;
            //this.fieldState = state;

            this.clickCommand = new DelegateCommand(this.OnClick, this.CanClick);
        }

        #endregion

        #region Properties

        public ICommand ClickCommand
        {
            get
            {
                return this.clickCommand;
            }
        }

        public String Field
        {
            get
            {
                return this.GetPath();
            }
        }

        public String UserField
        {
            get
            {
                // TODO compares badly
                if (this.fieldState.Equals(States.Empty))
                {
                    return this.GetUserColor();
                }
                else
                {
                    return this.Field;
                }
            }
        }

        public String EmptyField
        {
            get
            {
                return LayoutManager.EmptyField;
            }
        }

        public String WhiteField
        {
            get
            {
                return LayoutManager.WhiteField;
            }
        }

        public String BlackField
        {
            get
            {
                return LayoutManager.BlackField;
            }
        }

        public int FieldSize
        {
            get
            {
                if (Settings.BoardSize == BoardSizes.Board_19_19)
                {
                    return 40;
                }

                if (Settings.BoardSize == BoardSizes.Board_10_10)
                {
                    return 75;
                }

                return 40;
            }
        }

        #endregion

        #region Methods

        private String GetPath()
        {
            switch (this.fieldState)
            {
                case States.Black:
                    return this.BlackField;
                case States.White:
                    return this.WhiteField;
                default:
                    return this.EmptyField;
            }
        }

        private String GetUserColor()
        {
            if (this.gameController.Move == States.Black)
            {
                return this.BlackField;
            }
            return this.WhiteField;

            switch (this.gameController.Move)
            {
                case States.Black:
                    return this.BlackField;
                case States.White:
                    return this.WhiteField;
                default:
                    return this.EmptyField;
            }
        }

        /// <summary>
        /// Plays move.
        /// </summary>
        private void OnClick()
        {
            this.fieldState = this.gameController.Move;
            this.gameController.MakeMove(index);

            this.RaisePropertyChanged(() => this.Field);
            this.RaisePropertyChanged(() => this.UserField);
        }

        /// <summary>
        /// Player can not set stone,
        /// when the field is already occupied.
        /// </summary>
        /// <returns>If the move is correct.</returns>
        private bool CanClick()
        {
            if (this.fieldState == States.Empty)
            {
                return true;
            }

            return false;
        }

        public void Refresh()
        {
            // TODO new refresh method for recreating board

            //TODO move binding to the constructor
            this.fieldState = this.gameController.GameContext.Fields[index].FieldState;

            this.RaisePropertyChanged(() => this.Field);
            this.RaisePropertyChanged(() => this.UserField);
        }

        /// <summary>
        /// Refreshing after beating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewChanged(object sender, EventArgs e)
        {
            this.RaisePropertyChanged(() => this.Field);
            this.RaisePropertyChanged(() => this.UserField);
        }

        #endregion
    }
}
