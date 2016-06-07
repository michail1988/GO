using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Go.ViewModels;
using Microsoft.Practices.Prism.Commands;

namespace Go.Views
{
    public class ShellViewModel : BaseViewModel
    {
        #region Fields

        private DelegateCommand exitCommand;

        #endregion

        #region Constructors

        public ShellViewModel()
        {
            this.exitCommand = new DelegateCommand(this.ExitAction);
        }

        #endregion

        #region Properties

        public ICommand Exit
        {
            get
            {
                return this.exitCommand;
            }
        }

        public void ExitAction()
        {
            Application.Current.MainWindow.Close();
        }

        #endregion
    }
}
