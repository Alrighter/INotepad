using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notepad.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {

        public Model.ApplicationModel Model { get; set; } = new();
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand SaveAs => new(obj => Model.SaveFile(true));
        public RelayCommand Save => new(obj => Model.SaveFile(false));
        public RelayCommand NewFile => new(obj => Model.NewFile(true));
        public RelayCommand OpenFile => new(obj => Model.OpenFile(true));

    }
}
