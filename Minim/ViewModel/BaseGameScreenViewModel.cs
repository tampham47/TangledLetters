using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Minim {
    public abstract class BaseGameScreenViewModel : INotifyPropertyChanged {
        public BaseGameScreenViewModel() {

        }

        public bool IsDataLoaded {
            get;
            protected set;
        }

        abstract public void LoadData();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName) {
            if (null != PropertyChanged) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}