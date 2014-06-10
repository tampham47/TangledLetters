using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minim {
    public class PointViewModel : BaseGameScreenViewModel {
        public PointViewModel() {
            _posX = _posY = 0;
            _id = _typeId = -1;
        }

        public PointViewModel(double _x, double _y)
        {
            _posX = _x;
            _posY = _y;
        }

        //Lay du lieu tu model
        public override void LoadData() {
        }

        //Data of a Point
        private double _posX;
        private double _posY;
        private int _id;
        private int _typeId;
        private ImageSource _imgIcon;

        //Binding Property
        public double PosX {
            get {
                return _posX;
            }
            set {
                _posX = value;
                NotifyPropertyChanged("PosX");
            }
        }

        public double PosY {
            get {
                return _posY;

            }
            set {
                _posY = value;
                NotifyPropertyChanged("PosY");
            }
        }

        public int Id {
            get {
                return _id;

            }
            set {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public int TypeId {
            get {
                return _typeId;

            }
            set {
                _typeId = value;
                NotifyPropertyChanged("TypeId");
            }
        }

        public ImageSource ImgIcon {
            get {
                return _imgIcon;
            }
            set {
                _imgIcon = value;
                NotifyPropertyChanged("ImgIcon");
            }
        }
    }
}