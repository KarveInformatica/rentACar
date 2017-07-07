using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MainWindow
{
    class AnimalManager
    {
        Action<ViewModelBase> _action;

        public AnimalManager()
        {

        }

        public AnimalManager(Action<ViewModelBase> action)
        {
            _action = action;
        }

        ICommand _openanimals;
        public ICommand OpenAnimalsCommand
        {
            get
            {
                return _openanimals ?? new RouteCommand(async par => {
                    await Task.Run(() =>
                    {
                        AnimalVM animal = new AnimalVM();
                        ViewModelBase vmb = new ViewModelBase();
                        vmb.Header = "Animali";
                        vmb.Content = animal;

                        _action(vmb);
                    });
                });
            }
        }
    }
}
