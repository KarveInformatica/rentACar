using System.ComponentModel;

namespace KRibbon.Model.Generic
{
    /// <summary>
    ///  Abstract Class para el View Model.Classes
    /// </summary>
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}