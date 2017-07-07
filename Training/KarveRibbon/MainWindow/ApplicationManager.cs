using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainWindow
{
    class ApplicationManager:Notify
    {
        public ApplicationManager()
        {
            TabItems = new ObservableCollection<ViewModelBase>();
            PersonManager = new PersonManager(AddTab);
            AnimalManager = new AnimalManager(AddTab);

            TabItems.CollectionChanged += Tabs_CollectionChanged;
        }

        private void AddTab(ViewModelBase obj)
        {
            System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                TabItems.Add(obj);
            }));
        }

        private void Tabs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ViewModelBase added = e.NewItems[0] as ViewModelBase;
                System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() => SelectedTab = added));
            }
        }


        public static ObservableCollection<ViewModelBase> TabItems { get; set; }

        public PersonManager PersonManager { get; set; }
        public AnimalManager AnimalManager { get; set; }

        ViewModelBase _selectedtab;
        public ViewModelBase SelectedTab
        {
            get { return _selectedtab; }
            set
            {
                if (_selectedtab != value)
                {
                    _selectedtab = value;
                    OnChanged();
                }
            }
        }
    }
