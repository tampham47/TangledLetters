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

namespace Minim
{
    public class Level8
    {
        public Level8()
        {
        }

        public static ObservableCollection<PointViewModel> _points;
        public static ObservableCollection<ConnectorViewModel> _connectors;
        public static List<int> _correntWordIndex;
        public static List<int> _ambigiousLetter;
        public static List<int> _ambigiousConfusingLetter;
        public static string _imgurl;

        public static void GetLevel()
        {

            _imgurl = "/Minim;component/Resources/LevelIcon/Earth.png";

            _points = new ObservableCollection<PointViewModel>();
            _connectors = new ObservableCollection<ConnectorViewModel>();
            _correntWordIndex = new List<int>();
            _ambigiousLetter = new List<int>();
            _ambigiousConfusingLetter = new List<int>();

            _correntWordIndex.AddRange(new List<int>() { 0, 1, 2, 3, 4 });
            _ambigiousLetter.AddRange(new List<int>() { });
            PointViewModel viewmodel1 = new PointViewModel();
            viewmodel1.Id = 0;
            viewmodel1.PosX = 136;
            viewmodel1.PosY = 548;
            viewmodel1.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-E-icon.png", UriKind.Relative));
            _points.Add(viewmodel1);

            PointViewModel viewmodel2 = new PointViewModel();
            viewmodel2.Id = 1;
            viewmodel2.PosX = 385;
            viewmodel2.PosY = 309;
            viewmodel2.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-A-icon.png", UriKind.Relative));
            _points.Add(viewmodel2);

            PointViewModel viewmodel3 = new PointViewModel();
            viewmodel3.Id = 2;
            viewmodel3.PosX = 304;
            viewmodel3.PosY = 521;
            viewmodel3.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-R-icon.png", UriKind.Relative));
            _points.Add(viewmodel3);

            PointViewModel viewmodel4 = new PointViewModel();
            viewmodel4.Id = 3;
            viewmodel4.PosX = 354;
            viewmodel4.PosY = 31;
            viewmodel4.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-T-icon.png", UriKind.Relative));
            _points.Add(viewmodel4);

            PointViewModel viewmodel5 = new PointViewModel();
            viewmodel5.Id = 4;
            viewmodel5.PosX = 162;
            viewmodel5.PosY = 54;
            viewmodel5.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-H-icon.png", UriKind.Relative));
            _points.Add(viewmodel5);


            ConnectorViewModel connector1 = new ConnectorViewModel();
            connector1.PointId1 = 0;
            connector1.PointId2 = 1;
            connector1.Id = 0;
            _connectors.Add(connector1);

            ConnectorViewModel connector2 = new ConnectorViewModel();
            connector2.PointId1 = 0;
            connector2.PointId2 = 2;
            connector2.Id = 1;
            _connectors.Add(connector2);

            ConnectorViewModel connector3 = new ConnectorViewModel();
            connector3.PointId1 = 1;
            connector3.PointId2 = 3;
            connector3.Id = 2;
            _connectors.Add(connector3);

            ConnectorViewModel connector4 = new ConnectorViewModel();
            connector4.PointId1 = 1;
            connector4.PointId2 = 4;
            connector4.Id = 3;
            _connectors.Add(connector4);

            ConnectorViewModel connector5 = new ConnectorViewModel();
            connector5.PointId1 = 2;
            connector5.PointId2 = 3;
            connector5.Id = 4;
            _connectors.Add(connector5);

            ConnectorViewModel connector6 = new ConnectorViewModel();
            connector6.PointId1 = 2;
            connector6.PointId2 = 4;
            connector6.Id = 5;
            _connectors.Add(connector6);

        }
    }
}