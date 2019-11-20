using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyEventProject
{
    class PropChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _prop1;
        private string _prop2;

        public int Prop1
        {
            get => _prop1;
            set
            {
                _prop1 = value;
                NotifyPropertyChanged();
            }
        }

        public string Prop2
        {
            get => _prop2;
            set
            {
                _prop2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prop2"));
                //NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
