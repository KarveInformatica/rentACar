using KRibbon.Commands.Specific;
using KRibbon.Logic.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KRibbon.ViewModel
{
    class CloseWindowViewModel : ViewModelBase
    {
        private CloseWindowCommand closewindowcommand;

        public CloseWindowViewModel()
        {
            this.closewindowcommand = new CloseWindowCommand(this);
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return closewindowcommand;
            }
        }

        public void CloseWindow(object parameter)
        {
            Logic.Generic.CloseWindow.closeWindow();
        }
    }
}
