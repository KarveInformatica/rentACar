using KRibbon.Commands.Specific;
using KRibbon.Logic.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KRibbon.Model.Generic
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
