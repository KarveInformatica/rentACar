﻿using KRibbon.Commands.Generic;
using KRibbon.Model.Generic;
using KRibbon.ViewModel.GenericViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.Commands.Generic
{
    public class CloseTabItemCommand : ICommand
    {
        private CloseTabItemViewModel closetabitemvm;

        public CloseTabItemCommand() {}
        public CloseTabItemCommand(CloseTabItemViewModel vm)
        {
            this.closetabitemvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            closetabitemvm.CloseTabItem(parameter);         
        }
    }
}