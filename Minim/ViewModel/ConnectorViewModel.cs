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
    public class ConnectorViewModel : BaseGameScreenViewModel {
        public ConnectorViewModel() {
            //_posX1 = _posY1 = _posX2 = _posY2 = 0;
            _id = _typeId = -1;
            _pointId1 = _pointId2 = -1;
        }

        //Lay du lieu tu Model
        public override void LoadData() {

        }

        //Data of a Connector
        //private double _posX1;
        //private double _posY1;
        //private double _posX2;
        //private double _posY2;

        private int _pointId1;
        private int _pointId2;

        private int _id;
        private int _typeId;
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

        public int PointId2 {
            get {
                return _pointId2;

            }
            set {
                _pointId2 = value;
                NotifyPropertyChanged("PointId2");
            }
        }

        public int PointId1 {
            get {
                return _pointId1;

            }
            set {
                _pointId1 = value;
                NotifyPropertyChanged("PointId1");
            }
        }
    }
}


       
   