using MainWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow
{
    class AnimalVM
    {

        public AnimalVM()
        {
            IsLoaded = true;
            Animals = new ObservableCollection<Animal>();
        }

        async Task mm()
        {
            await Task.Factory.StartNew(() =>
            {
                System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    for (int i = 0; i < 100000; i++)
                    {
                        Animals.Add(new AnimalVM { Genre = $"Cat {i}" });
                        Animals.Add(new Animal { Genre = $"Dog {i}", IsChecked = true });
                        Animals.Add(new Animal { Genre = $"Mouse {i}" });

                    }
                    IsLoaded = false;
                }));
            });

        }

        public void GetAnimals()
        {
            Task.Factory.StartNew(async () => await mm());
        }

        public ObservableCollection<Animal> Animals { get; set; }

        Animal _selectedanimal;
        public Animal SelectedAnimal
        {
            get { return _selectedanimal; }
            set
            {
                if (_selectedanimal != value)
                {
                    _selectedanimal = value;
                    OnChanged();
                }
            }
        }

        bool _isloaded;
        public bool IsLoaded
        {
            get { return _isloaded; }
            set
            {
                if (_isloaded != value)
                {
                    _isloaded = value;
                    OnChanged();
                }
            }
        }

    }
}
