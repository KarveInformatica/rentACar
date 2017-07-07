using KRibbon.Commands.Generic;
using KRibbon.Logic.Generic;
using KRibbon.Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KRibbon.ViewModel.GenericViewModel
{
    class CloseWindowViewModel : PropertyChangedBase
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
