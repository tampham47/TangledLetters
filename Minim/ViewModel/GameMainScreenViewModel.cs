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
    public class GameMainScreenViewModel : BaseGameScreenViewModel {
        public GameMainScreenViewModel() {
            this._points = new ObservableCollection<PointViewModel>();
            this._connectors = new ObservableCollection<ConnectorViewModel>();
			this._correctWordIndex = new List<int>();
			this._ambigiousLetter = new List<int>();
            this._ambigiousConfusingLetter = new List<int>();
			this._alreadyLetter = new List<int>();
            this._alreadyConnector = new List<int>();
            this.IsDataLoaded = false;
        }
		
		private void ResetLevel(){
			this._points.Clear();
            this._connectors.Clear();
			this._correctWordIndex.Clear();
			this._ambigiousLetter.Clear();
            this._ambigiousConfusingLetter.Clear();
			this._alreadyLetter.Clear();
            this._alreadyConnector.Clear();              
			
			GameConstants.CURRENT_ID = 0;
			GameConstants.CURRENT_X = GameConstants.BASKET_X;
			GameConstants.CURRENT_Y = GameConstants.BASKET_Y;
		}
		
		public void LoadData(int level){
			switch (level){
				case 1:
                    Level1.GetLevel();
					_correctWordIndex.AddRange(Level1._correntWordIndex);
					_ambigiousLetter.AddRange(Level1._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level1._ambigiousConfusingLetter);
					
					foreach (PointViewModel viewmodel in Level1._points){
						_points.Add(viewmodel);
					}
					
					foreach (ConnectorViewModel viewmodel in Level1._connectors){
						_connectors.Add(viewmodel);
					}

                    _backgroundFigure = new BitmapImage(new Uri(Level1._imgurl, UriKind.Relative));
					break;
				case 2:
					Level2.GetLevel();
					_correctWordIndex.AddRange(Level2._correntWordIndex);
					_ambigiousLetter.AddRange(Level2._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level2._ambigiousConfusingLetter);
					
					foreach (PointViewModel viewmodel in Level2._points){
						_points.Add(viewmodel);
					}
					
					foreach (ConnectorViewModel viewmodel in Level2._connectors){
						_connectors.Add(viewmodel);
					}

                    _backgroundFigure = new BitmapImage(new Uri(Level2._imgurl, UriKind.Relative));
					break;
				case 3:
					Level3.GetLevel();
					_correctWordIndex.AddRange(Level3._correntWordIndex);
					_ambigiousLetter.AddRange(Level3._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level3._ambigiousConfusingLetter);
					
					foreach (PointViewModel viewmodel in Level3._points){
						_points.Add(viewmodel);
					}
					
					foreach (ConnectorViewModel viewmodel in Level3._connectors){
						_connectors.Add(viewmodel);
					}

                    _backgroundFigure = new BitmapImage(new Uri(Level3._imgurl, UriKind.Relative));
					break;
                case 4:
                    Level4.GetLevel();
                    _correctWordIndex.AddRange(Level4._correntWordIndex);
                    _ambigiousLetter.AddRange(Level4._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level4._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level4._points) {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level4._connectors) {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level4._imgurl, UriKind.Relative));
                    break;
                case 5:
                    Level5.GetLevel();
                    _correctWordIndex.AddRange(Level5._correntWordIndex);
                    _ambigiousLetter.AddRange(Level5._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level5._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level5._points)
                    {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level5._connectors)
                    {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level5._imgurl, UriKind.Relative));
                    break;
                case 6:
                    Level6.GetLevel();
                    _correctWordIndex.AddRange(Level6._correntWordIndex);
                    _ambigiousLetter.AddRange(Level6._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level6._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level6._points)
                    {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level6._connectors)
                    {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level6._imgurl, UriKind.Relative));
                    break;
                case 7:
                    Level7.GetLevel();
                    _correctWordIndex.AddRange(Level7._correntWordIndex);
                    _ambigiousLetter.AddRange(Level7._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level7._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level7._points)
                    {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level7._connectors)
                    {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level7._imgurl, UriKind.Relative));
                    break;
                case 8:
                    Level8.GetLevel();
                    _correctWordIndex.AddRange(Level8._correntWordIndex);
                    _ambigiousLetter.AddRange(Level8._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level8._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level8._points)
                    {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level8._connectors)
                    {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level8._imgurl, UriKind.Relative));
                    break;
                case 9:
                    Level9.GetLevel();
                    _correctWordIndex.AddRange(Level9._correntWordIndex);
                    _ambigiousLetter.AddRange(Level9._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level9._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level9._points)
                    {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level9._connectors)
                    {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level9._imgurl, UriKind.Relative));
                    break;
                case 10:
                    Level10.GetLevel();
                    _correctWordIndex.AddRange(Level10._correntWordIndex);
                    _ambigiousLetter.AddRange(Level10._ambigiousLetter);
                    _ambigiousConfusingLetter.AddRange(Level10._ambigiousConfusingLetter);

                    foreach (PointViewModel viewmodel in Level10._points)
                    {
                        _points.Add(viewmodel);
                    }

                    foreach (ConnectorViewModel viewmodel in Level10._connectors)
                    {
                        _connectors.Add(viewmodel);
                    }

                    _backgroundFigure = new BitmapImage(new Uri(Level10._imgurl, UriKind.Relative));
                    break;
					
			}		
		}

        public override void LoadData() {
			ResetLevel();
			LoadData(GameConstants.CURRENT_LEVEL);
            this.IsDataLoaded = true;
        }

        //ViewModel Data
        private ObservableCollection<PointViewModel> _points;
        private ObservableCollection<ConnectorViewModel> _connectors;
		private List<int> _correctWordIndex;
		private List<int> _ambigiousLetter;
        private List<int> _ambigiousConfusingLetter;
		private List<int> _alreadyLetter;
        private List<int> _alreadyConnector;
        private ImageSource _backgroundFigure;

        //Binding Property
        public ObservableCollection<PointViewModel> Points {
            get {
                return _points;
            }
            private set {
                _points = value;
                NotifyPropertyChanged("Points");
            }
        }

        public ObservableCollection<ConnectorViewModel> Connectors {
            get {
                return _connectors;
            }
            private set {
                _connectors = value;
                NotifyPropertyChanged("Connectors");
            }
        }
		
		public List<int> CorrectWordIndex {
            get {
                return _correctWordIndex;
            }
            private set {
                _correctWordIndex = value;
                NotifyPropertyChanged("CorrectWordIndex");
            }
        }
		
		public List<int> AmbigiousLetter {
            get {
                return _ambigiousLetter;
            }
            private set {
                _ambigiousLetter = value;
                NotifyPropertyChanged("AmbigiousLetter");
            }
        }

        public List<int> AmbigiousConfusingLetter {
            get {
                return _ambigiousConfusingLetter;
            }
            private set {
                _ambigiousConfusingLetter = value;
                NotifyPropertyChanged("AmbigiousConfusingLetter");
            }
        }
		
		public List<int> AlreadyLetter {
            get {
                return _alreadyLetter;
            }
            private set {
                _alreadyLetter = value;
                NotifyPropertyChanged("AlreadyLetter");
            }
        }

        public List<int> AlreadyConnector {
            get {
                return _alreadyConnector;
            }
            private set {
                _alreadyConnector = value;
                NotifyPropertyChanged("AlreadyConnector");
            }
        }

        public ImageSource BackgroundFigure {
            get {
                return _backgroundFigure;
            }
            set {
                _backgroundFigure = value;
                NotifyPropertyChanged("BackgroundFigure");
            }
        }
		
    }
}