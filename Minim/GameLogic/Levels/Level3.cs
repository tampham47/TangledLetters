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
	public class Level3
	{
		public Level3()
		{			
		}
		
		public static ObservableCollection<PointViewModel> _points;
        public static ObservableCollection<ConnectorViewModel> _connectors;
		public static List<int> _correntWordIndex;
		public static List<int> _ambigiousLetter;
        public static List<int> _ambigiousConfusingLetter;

		public static string _imgurl;
		
		public static void GetLevel(){
			
			_imgurl = "/Minim;component/Resources/LevelIcon/dolphin_icon.png";
			
			_points = new ObservableCollection<PointViewModel>();
            _connectors = new ObservableCollection<ConnectorViewModel>();
			_correntWordIndex = new List<int>();
			_ambigiousLetter = new List<int>();
            _ambigiousConfusingLetter = new List<int>();
			
			_correntWordIndex.AddRange(new List<int>(){ 0, 1, 2, 3, 4, 5, 6 });
			_ambigiousLetter.AddRange(new List<int>(){ });
            PointViewModel viewmodel1 = new PointViewModel();
            viewmodel1.Id = 0;
            viewmodel1.PosX = 389;
            viewmodel1.PosY = 138;
            viewmodel1.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-D-icon.png", UriKind.Relative));
            _points.Add(viewmodel1);

            PointViewModel viewmodel2 = new PointViewModel();
            viewmodel2.Id = 1;
            viewmodel2.PosX = 115;
            viewmodel2.PosY = 308;
            viewmodel2.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-O-icon.png", UriKind.Relative));
            _points.Add(viewmodel2);

            PointViewModel viewmodel3 = new PointViewModel();
            viewmodel3.Id = 2;
            viewmodel3.PosX = 252;
            viewmodel3.PosY = 308;
            viewmodel3.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-L-icon.png", UriKind.Relative));
            _points.Add(viewmodel3);

            PointViewModel viewmodel4 = new PointViewModel();
            viewmodel4.Id = 3;
            viewmodel4.PosX = 115;
            viewmodel4.PosY = 478;
            viewmodel4.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-P-icon.png", UriKind.Relative));
            _points.Add(viewmodel4);

            PointViewModel viewmodel5 = new PointViewModel();
            viewmodel5.Id = 4;
            viewmodel5.PosX = 389;
            viewmodel5.PosY = 478;
            viewmodel5.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-H-icon.png", UriKind.Relative));
            _points.Add(viewmodel5);

            PointViewModel viewmodel6 = new PointViewModel();
            viewmodel6.Id = 5;
            viewmodel6.PosX = 389;
            viewmodel6.PosY = 308;
            viewmodel6.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-I-icon.png", UriKind.Relative));
            _points.Add(viewmodel6);

			PointViewModel viewmodel7 = new PointViewModel();
            viewmodel7.Id = 6;
            viewmodel7.PosX = 115;
            viewmodel7.PosY = 138;
            viewmodel7.ImgIcon = new BitmapImage(new Uri("/Minim;component/Resources/LetterIcon/Letter-N-icon.png", UriKind.Relative));
            _points.Add(viewmodel7);
			
            ConnectorViewModel connector1 = new ConnectorViewModel();
            connector1.PointId1 = 0;
            connector1.PointId2 = 1;
            connector1.Id = 0;
            _connectors.Add(connector1);

            ConnectorViewModel connector2 = new ConnectorViewModel();
            connector2.PointId1 = 0;
            connector2.PointId2 = 3;
            connector2.Id = 1;
            _connectors.Add(connector2);

            ConnectorViewModel connector3 = new ConnectorViewModel();
            connector3.PointId1 = 1;
            connector3.PointId2 = 2;
            connector3.Id = 2;
            _connectors.Add(connector3);

            ConnectorViewModel connector4 = new ConnectorViewModel();
            connector4.PointId1 = 2;
            connector4.PointId2 = 3;
            connector4.Id = 3;
            _connectors.Add(connector4);

            ConnectorViewModel connector5 = new ConnectorViewModel();
            connector5.PointId1 = 2;
            connector5.PointId2 = 4;
            connector5.Id = 4;
            _connectors.Add(connector5);

            ConnectorViewModel connector6 = new ConnectorViewModel();
            connector6.PointId1 = 3;
            connector6.PointId2 = 5;
            connector6.Id = 5;
            _connectors.Add(connector6);

            ConnectorViewModel connector7 = new ConnectorViewModel();
            connector7.PointId1 = 1;
            connector7.PointId2 = 4;
            connector7.Id = 6;
            _connectors.Add(connector7);

            ConnectorViewModel connector8 = new ConnectorViewModel();
            connector8.PointId1 = 2;
            connector8.PointId2 = 5;
            connector8.Id = 7;
            _connectors.Add(connector8);
			
			ConnectorViewModel connector9 = new ConnectorViewModel();
            connector9.PointId1 = 4;
            connector9.PointId2 = 6;
            connector9.Id = 8;
            _connectors.Add(connector9);
			
			ConnectorViewModel connector10 = new ConnectorViewModel();
            connector10.PointId1 = 5;
            connector10.PointId2 = 6;
            connector10.Id = 9;
            _connectors.Add(connector10);
		}
	}
}