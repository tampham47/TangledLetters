using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;

namespace Minim {
    public partial class GameMainView : UserControl {

        public GameMainView() {
            InitializeComponent();
            _pointViewList = new List<PointView>();
            _connectorViewList = new List<ConnectorView>();            
            this._storyboards = new List<Storyboard>();
			this._storyboards2 = new List<Storyboard>();
			this.btnNext.Visibility = Visibility.Collapsed;
			
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e) {
            this.DataContext = App.GameMainViewModel;

            //if (!App.GameMainViewModel.IsDataLoaded) {
                //App.GameMainViewModel.LoadData();
            //}

            LoadDataFromViewModel();            
        }
		
		public void LoadDataFromViewModel(){			
			parentCanvas.Children.Clear();
			
			App.GameMainViewModel.LoadData();
			_pointViewList.Clear();
            _connectorViewList.Clear();       
            this._storyboards.Clear();
			this._storyboards2.Clear();
			
			GeneratePoints();
            GenerateConnectors();
			
			backgroundFigure.Source = App.GameMainViewModel.BackgroundFigure;
            this.SuccessAnimation.Stop();
		}

        private void GeneratePoints() {
            foreach (PointViewModel viewmodel in App.GameMainViewModel.Points) {
                PointView view = new PointView();
                view.SetValue(HeightProperty, Double.NaN);
                view.SetValue(WidthProperty, Double.NaN);
                Canvas.SetZIndex(view, 2);
                view.RenderTransformOrigin = new Point(0.5, 0.5);

                Binding b1 = new Binding();
                b1.Source = viewmodel;
                b1.Path = new PropertyPath("PosX");
                b1.Mode = BindingMode.TwoWay;

                Binding b2 = new Binding();
                b2.Source = viewmodel;
                b2.Path = new PropertyPath("PosY");
                b2.Mode = BindingMode.TwoWay;

                CompositeTransform tran = new CompositeTransform();
                view.RenderTransform = tran;
                tran.TranslateX = viewmodel.PosX;
                tran.TranslateY = viewmodel.PosY;

                view.SetBinding(PointView.posX, b1);
                view.SetBinding(PointView.posY, b2);

                view.DataContext = viewmodel;
                parentCanvas.Children.Add(view);
                view.Name = "point" + viewmodel.Id.ToString();
                _pointViewList.Add(view);
                view.DoubleTap += new System.EventHandler<System.Windows.Input.GestureEventArgs>(view_DoubleTap);
           
				view.Hold += new System.EventHandler<System.Windows.Input.GestureEventArgs>(view_Hold);

                view.OnBoardAnimation.Completed += new EventHandler(OnBoardAnimation_Completed);
                view.Tap += new EventHandler<GestureEventArgs>(view_Tap);
				view.SetUseDragable(true);
            }
        }

        void view_Tap(object sender, GestureEventArgs e) {
            PointView view = sender as PointView;
            PointViewModel viewmodel = view.DataContext as PointViewModel;
            //view.OnBoardAnimation.Stop();
            if (GameConstants.CURRENT_ID >= App.GameMainViewModel.CorrectWordIndex.Count) {
                //IsOK = false;
                return;
            }
            //if (IsOK ||  GameConstants.CURRENT_ID == 0) { 
            //IsOK = false;                               

            if (App.GameMainViewModel.AlreadyLetter.Contains(viewmodel.Id)) {
                //IsOK = false;
                return;
            }

            if (App.GameMainViewModel.CorrectWordIndex[GameConstants.CURRENT_ID] == viewmodel.Id || 
                (App.GameMainViewModel.CorrectWordIndex[GameConstants.CURRENT_ID] < 0 
                    && App.GameMainViewModel.AmbigiousLetter.Contains(viewmodel.Id)
                    && App.GameMainViewModel.AmbigiousConfusingLetter[App.GameMainViewModel.AmbigiousLetter.IndexOf(viewmodel.Id)] == App.GameMainViewModel.CorrectWordIndex[GameConstants.CURRENT_ID])) {
               
                List<int> vertices = new List<int>();

                List<PointViewModel> vertices_out = new List<PointViewModel>();
                List<ConnectorViewModel> connectors_out = new List<ConnectorViewModel>();
                List<PointViewModel> vertices_in = new List<PointViewModel>();
                List<ConnectorViewModel> connectors_in = new List<ConnectorViewModel>();

                vertices_in.AddRange(App.GameMainViewModel.Points);
                connectors_in.AddRange(App.GameMainViewModel.Connectors);

                if (MathNew.AddConnPoint(vertices_in, connectors_in, ref vertices_out, ref connectors_out, viewmodel)) {

                    vertices.Add(viewmodel.Id);
                    foreach (PointViewModel v in vertices_out) {
                        vertices.Add(v.Id);
                    }

                    App.GameMainViewModel.AlreadyLetter.Add(vertices[0]);
                    foreach (ConnectorViewModel v in connectors_out) {
                        App.GameMainViewModel.AlreadyConnector.Add(v.Id);
                    }
					
                    this.Execute2(vertices, GameConstants.CURRENT_X, GameConstants.CURRENT_Y);
                    GameConstants.CURRENT_ID++;
                    GameConstants.CURRENT_X += GameConstants.NEXT_X;
                    GameConstants.CURRENT_Y += GameConstants.NEXT_Y;                    
                }
				
				if (GameConstants.CURRENT_ID == App.GameMainViewModel.CorrectWordIndex.Count){
					//Success
					this.SuccessAnimation.Begin();
					this.SuccessAnimation.Completed += new System.EventHandler(SuccessAnimation_Completed);
				}
            }
            
        }

        void OnBoardAnimation_Completed(object sender, EventArgs e) {
            IsOK = true;
        }

        private void GenerateConnectors() {
            foreach (ConnectorViewModel viewmodel in App.GameMainViewModel.Connectors) {
                ConnectorView view = new ConnectorView();
                view.SetValue(HeightProperty, Double.NaN);
                view.SetValue(WidthProperty, Double.NaN);
                Canvas.SetZIndex(view, 0);

                Binding b1 = new Binding();
                b1.Source = App.GameMainViewModel.Points[viewmodel.PointId1];
                b1.Path = new PropertyPath("PosX");
                b1.Mode = BindingMode.TwoWay;

                Binding b2 = new Binding();
                b2.Source = App.GameMainViewModel.Points[viewmodel.PointId1];
                b2.Path = new PropertyPath("PosY");
                b2.Mode = BindingMode.TwoWay;

                Binding b3 = new Binding();
                b3.Source = App.GameMainViewModel.Points[viewmodel.PointId2];
                b3.Path = new PropertyPath("PosX");
                b3.Mode = BindingMode.TwoWay;

                Binding b4 = new Binding();
                b4.Source = App.GameMainViewModel.Points[viewmodel.PointId2];
                b4.Path = new PropertyPath("PosY");
                b4.Mode = BindingMode.TwoWay;

                view.SetBinding(ConnectorView.posX1, b1);
                view.SetBinding(ConnectorView.posY1, b2);
                view.SetBinding(ConnectorView.posX2, b3);
                view.SetBinding(ConnectorView.posY2, b4);

                view.DataContext = viewmodel;
                parentCanvas.Children.Add(view);
                _connectorViewList.Add(view);
            }
        }

        private List<PointView> _pointViewList;
        private List<ConnectorView> _connectorViewList;

        public void ExecuteAnimation(List<int> vertices) {
            List<int> temp = vertices.GetRange(1, vertices.Count - 1);			
			
            this.MoveAnimation.FillBehavior = FillBehavior.HoldEnd;
            this.MoveAnimation2.FillBehavior = FillBehavior.HoldEnd;
            this.MoveAnimation.Children.Clear();
            this.MoveAnimation2.Children.Clear();

            Timeline t1;
            Timeline t2;
            Timeline t11;
            Timeline t22;

            SineEase ease = new SineEase();
            ease.EasingMode = EasingMode.EaseOut;

            QuarticEase ease2 = new QuarticEase();
            ease2.EasingMode = EasingMode.EaseOut;

            foreach (int i in temp) {
                t1 = new DoubleAnimation();
                t1.SetValue(DoubleAnimation.ToProperty, _pointViewList[vertices[0]].PosX);
                Storyboard.SetTarget(t1, _pointViewList[i]);
                Storyboard.SetTargetProperty(t1, new PropertyPath("PosX"));
                t1.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));

                t11 = new DoubleAnimation();
                t11.SetValue(DoubleAnimation.ToProperty, _pointViewList[vertices[0]].PosY);
                Storyboard.SetTarget(t11, _pointViewList[i]);
                Storyboard.SetTargetProperty(t11, new PropertyPath("PosY"));
                t11.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));


                t2 = new DoubleAnimation();
                t2.SetValue(DoubleAnimation.ToProperty, _pointViewList[vertices[0]].PosX);
                Storyboard.SetTarget(t2, _pointViewList[i]);
                Storyboard.SetTargetProperty(t2, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
                t2.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));

                t22 = new DoubleAnimation();
                t22.SetValue(DoubleAnimation.ToProperty, _pointViewList[vertices[0]].PosY);
                Storyboard.SetTarget(t22, _pointViewList[i]);
                Storyboard.SetTargetProperty(t22, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)"));
                t22.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));

                (t1 as DoubleAnimation).EasingFunction = ease2;
                (t11 as DoubleAnimation).EasingFunction = ease2;

                (t2 as DoubleAnimation).EasingFunction = ease;
                (t22 as DoubleAnimation).EasingFunction = ease;

                this.MoveAnimation.Children.Add(t1);
                this.MoveAnimation.Children.Add(t11);

                this.MoveAnimation2.Children.Add(t2);
                this.MoveAnimation2.Children.Add(t22);
            }

            this.MoveAnimation.Begin();
            this.MoveAnimation2.Begin();
        }
		
		private List<Storyboard> _storyboards;
		private List<Storyboard> _storyboards2;

        public void ExecuteAnimation2(List<int> vertices, double letterX, double letterY) {
            //List<int> temp = vertices.GetRange(1, vertices.Count - 1);

			Storyboard st = new Storyboard();
			Storyboard st2 = new Storyboard();
			
            st.FillBehavior = FillBehavior.HoldEnd;
            st2.FillBehavior = FillBehavior.HoldEnd;
            st.Children.Clear();
            st2.Children.Clear();

            Timeline t1;
            Timeline t2;
            Timeline t11;
            Timeline t22;

            SineEase ease = new SineEase();
            ease.EasingMode = EasingMode.EaseOut;

            QuarticEase ease2 = new QuarticEase();
            ease2.EasingMode = EasingMode.EaseOut;

            //foreach (int i in vertices) {
            t1 = new DoubleAnimation();
            t1.SetValue(DoubleAnimation.ToProperty, letterX);
            Storyboard.SetTarget(t1, _pointViewList[vertices[0]]);
            Storyboard.SetTargetProperty(t1, new PropertyPath("PosX"));
            t1.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));

            t11 = new DoubleAnimation();
            t11.SetValue(DoubleAnimation.ToProperty, letterY);
            Storyboard.SetTarget(t11, _pointViewList[vertices[0]]);
            Storyboard.SetTargetProperty(t11, new PropertyPath("PosY"));
            t11.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));


            t2 = new DoubleAnimation();
            t2.SetValue(DoubleAnimation.ToProperty, letterX);
            Storyboard.SetTarget(t2, _pointViewList[vertices[0]]);
            Storyboard.SetTargetProperty(t2, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
            t2.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));

            t22 = new DoubleAnimation();
            t22.SetValue(DoubleAnimation.ToProperty, letterY);
            Storyboard.SetTarget(t22, _pointViewList[vertices[0]]);
            Storyboard.SetTargetProperty(t22, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)"));
            t22.Duration = new Duration(TimeSpan.FromSeconds(GameConstants.GAME_SPEED / 2));

            (t1 as DoubleAnimation).EasingFunction = ease2;
            (t11 as DoubleAnimation).EasingFunction = ease2;

            (t2 as DoubleAnimation).EasingFunction = ease;
            (t22 as DoubleAnimation).EasingFunction = ease;

            st.Children.Add(t1);
            st.Children.Add(t11);

            st2.Children.Add(t2);
            st2.Children.Add(t22);
            //}

            _storyboards.Insert(0, st);
			_storyboards2.Insert(0, st2);		
			
        }

        public void Execute2(List<int> vertices, double letterX, double letterY) {            
			
			foreach (ConnectorViewModel viewmodel in App.GameMainViewModel.Connectors) {                        
                if (App.GameMainViewModel.AlreadyConnector.Contains(viewmodel.Id)) {
                    _connectorViewList[viewmodel.Id].Visibility = Visibility.Collapsed;  
                    if (viewmodel.PointId1 == vertices[0]) {                                
                        (_pointViewList[viewmodel.PointId1].RenderTransform as CompositeTransform).TranslateX = _pointViewList[viewmodel.PointId1].PosX;
                        (_pointViewList[viewmodel.PointId1].RenderTransform as CompositeTransform).TranslateY = _pointViewList[viewmodel.PointId1].PosY;
                    }
                    if (viewmodel.PointId2 == vertices[0]) {                                
                        (_pointViewList[viewmodel.PointId2].RenderTransform as CompositeTransform).TranslateX = _pointViewList[viewmodel.PointId2].PosX;
                        (_pointViewList[viewmodel.PointId2].RenderTransform as CompositeTransform).TranslateY = _pointViewList[viewmodel.PointId2].PosY;
					}
				}
			}
			
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = TimeSpan.FromSeconds(GameConstants.GAME_SPEED - 0.3d);
            bool isFinished = false;
            //List<int> temp = vertices.GetRange(1, vertices.Count - 1);

            //foreach (int i in vertices) {
            _pointViewList[vertices[0]].BlastAnimation.Begin();
            //}

            t.Tick += delegate(object sender, EventArgs e) {
                this.MoveAnimation.Stop();
                this.MoveAnimation2.Stop();

                if (!isFinished) {
					
					ExecuteAnimation2(vertices, letterX, letterY);
                    _storyboards[0].Begin();
					_storyboards2[0].Begin();
					
                    _pointViewList[vertices[0]].Visibility = Visibility.Visible;
                    isFinished = true;

                    //Timeline t2;
                    //Timeline t22;

                    //SineEase ease = new SineEase();
                    //ease.EasingMode = EasingMode.EaseIn;

                    //foreach (int i in vertices) {
                    //t2 = new DoubleAnimation();
                    //t2.SetValue(DoubleAnimation.ToProperty, GameConstants.BASKET_X - 20);
                    //Storyboard.SetTarget(t2, _pointViewList[vertices[0]]);
                    //Storyboard.SetTargetProperty(t2, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
                    //t2.Duration = new Duration(TimeSpan.FromSeconds(0.25));

                    //t22 = new DoubleAnimation();
                    //t22.SetValue(DoubleAnimation.ToProperty, GameConstants.BASKET_Y);
                    //Storyboard.SetTarget(t22, _pointViewList[vertices[0]]);
                    //Storyboard.SetTargetProperty(t22, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)"));
                    //t22.Duration = new Duration(TimeSpan.FromSeconds(0.25));

                    //(t2 as DoubleAnimation).EasingFunction = ease;
                    //(t22 as DoubleAnimation).EasingFunction = ease;

                    //this.DropAnimation.Children.Add(t2);
                    //this.DropAnimation.Children.Add(t22);
                    //}
                    //this.DropAnimation.FillBehavior = FillBehavior.HoldEnd;
                    //this.DropAnimation.Begin();	
                    //_pointViewList[vertices[0]].OnBoardAnimation.Begin();
					//_pointViewList[vertices[0]].OnBoardAnimation.FillBehavior = FillBehavior.Stop;
                } else {
                    //foreach (int i in vertices) {
					//_pointViewList[vertices[0]].OnBoardAnimation.Stop();
                    //this.DropAnimation.Stop();
                    //_pointViewList[vertices[0]].OnBoardAnimation.Stop();
                    //(_pointViewList[vertices[0]].RenderTransform as CompositeTransform).TranslateX = GameConstants.BASKET_X - 20;
                    //(_pointViewList[vertices[0]].RenderTransform as CompositeTransform).TranslateY = GameConstants.BASKET_Y;
                    (_pointViewList[vertices[0]].RenderTransform as CompositeTransform).TranslateX = letterX;
                    (_pointViewList[vertices[0]].RenderTransform as CompositeTransform).TranslateY = letterY;
                    //_pointViewList[vertices[0]].BlastAnimation.Stop();
                    //_pointViewList[vertices[0]].DisappearAnimation.Begin();
                    //_pointViewList[vertices[0]].DisappearAnimation.FillBehavior = FillBehavior.HoldEnd;
                    _pointViewList[vertices[0]].SetValue(Canvas.ZIndexProperty, 1);
                    //_pointViewList[vertices[0]].StaticAnimation.Stop();
					
                    //}
					_pointViewList[vertices[0]].SetUseDragable(false);
                    t.Stop();					
                }
            };
            t.Start();
        }

        public void Execute(List<int> vertices) {
            ExecuteAnimation(vertices);

            DispatcherTimer t = new DispatcherTimer();
            t.Interval = TimeSpan.FromSeconds(GameConstants.GAME_SPEED);
            bool isFinished = false;
            List<int> temp = vertices.GetRange(1, vertices.Count - 1);

            foreach (int i in temp) {
                _pointViewList[i].BlastAnimation.Begin();
            }

            t.Tick += delegate(object sender, EventArgs e) {
                this.MoveAnimation.Stop();
                this.MoveAnimation2.Stop();
                if (!isFinished) {

                    foreach (ConnectorViewModel viewmodel in App.GameMainViewModel.Connectors) {
                        if (vertices.Contains(viewmodel.PointId1) && vertices.Contains(viewmodel.PointId2)) {
                            _connectorViewList[viewmodel.Id].Visibility = Visibility.Collapsed;

                            if (viewmodel.PointId1 != vertices[0]) {
                                (_pointViewList[viewmodel.PointId1].RenderTransform as CompositeTransform).TranslateX = _pointViewList[viewmodel.PointId1].PosX;
                                (_pointViewList[viewmodel.PointId1].RenderTransform as CompositeTransform).TranslateY = _pointViewList[viewmodel.PointId1].PosY;
                            }
                            if (viewmodel.PointId2 != vertices[0]) {
                                (_pointViewList[viewmodel.PointId2].RenderTransform as CompositeTransform).TranslateX = _pointViewList[viewmodel.PointId2].PosX;
                                (_pointViewList[viewmodel.PointId2].RenderTransform as CompositeTransform).TranslateY = _pointViewList[viewmodel.PointId2].PosY;
                            }
                        }

                        if (!vertices.Contains(viewmodel.PointId1) && !vertices.Contains(viewmodel.PointId2)) {
                            continue;
                        }

                        if (temp.Contains(viewmodel.PointId1)) {
                            viewmodel.PointId1 = vertices[0];

                            Binding b1 = new Binding();
                            b1.Path = new PropertyPath("PosX");
                            b1.Mode = BindingMode.TwoWay;
                            b1.Source = App.GameMainViewModel.Points[viewmodel.PointId1];

                            Binding b2 = new Binding();
                            b2.Path = new PropertyPath("PosY");
                            b2.Mode = BindingMode.TwoWay;
                            b2.Source = App.GameMainViewModel.Points[viewmodel.PointId1];

                            _connectorViewList[viewmodel.Id].SetBinding(ConnectorView.posX1, b1);
                            _connectorViewList[viewmodel.Id].SetBinding(ConnectorView.posY1, b2);
                        }

                        if (temp.Contains(viewmodel.PointId2)) {
                            viewmodel.PointId2 = vertices[0];
                            Binding b1 = new Binding();
                            b1.Path = new PropertyPath("PosX");
                            b1.Mode = BindingMode.TwoWay;
                            b1.Source = App.GameMainViewModel.Points[viewmodel.PointId2];

                            Binding b2 = new Binding();
                            b2.Path = new PropertyPath("PosY");
                            b2.Mode = BindingMode.TwoWay;
                            b2.Source = App.GameMainViewModel.Points[viewmodel.PointId2];

                            _connectorViewList[viewmodel.Id].SetBinding(ConnectorView.posX2, b1);
                            _connectorViewList[viewmodel.Id].SetBinding(ConnectorView.posY2, b2);
                        }
                    }
                    _pointViewList[vertices[0]].Visibility = Visibility.Visible;
                    isFinished = true;

                    Timeline t2;
                    Timeline t22;

                    SineEase ease = new SineEase();
                    ease.EasingMode = EasingMode.EaseIn;

                    foreach (int i in temp) {
                        t2 = new DoubleAnimation();
                        t2.SetValue(DoubleAnimation.ToProperty, GameConstants.BASKET_X - 20);
                        Storyboard.SetTarget(t2, _pointViewList[i]);
                        Storyboard.SetTargetProperty(t2, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
                        t2.Duration = new Duration(TimeSpan.FromSeconds(0.25));

                        t22 = new DoubleAnimation();
                        t22.SetValue(DoubleAnimation.ToProperty, GameConstants.BASKET_Y);
                        Storyboard.SetTarget(t22, _pointViewList[i]);
                        Storyboard.SetTargetProperty(t22, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)"));
                        t22.Duration = new Duration(TimeSpan.FromSeconds(0.25));

                        (t2 as DoubleAnimation).EasingFunction = ease;
                        (t22 as DoubleAnimation).EasingFunction = ease;

                        this.DropAnimation.Children.Add(t2);
                        this.DropAnimation.Children.Add(t22);
                    }
                    this.DropAnimation.FillBehavior = FillBehavior.HoldEnd;
                    this.DropAnimation.Begin();
                } else {
                    foreach (int i in temp) {
                        this.DropAnimation.Stop();
                        (_pointViewList[i].RenderTransform as CompositeTransform).TranslateX = GameConstants.BASKET_X - 20;
                        (_pointViewList[i].RenderTransform as CompositeTransform).TranslateY = GameConstants.BASKET_Y;
                        _pointViewList[i].BlastAnimation.Stop();
                        _pointViewList[i].DisappearAnimation.Begin();
                        _pointViewList[i].DisappearAnimation.FillBehavior = FillBehavior.HoldEnd;
                        _pointViewList[i].SetValue(Canvas.ZIndexProperty, 1);
                        _pointViewList[i].StaticAnimation.Stop();
                    }
                    t.Stop();
                }
            };
            t.Start();
        }

        private bool IsOK = false;

        private void view_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e) {
            
		}

        private void view_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
			PointView view = sender as PointView;
            txt1.Text = view.PosX.ToString();
			txt2.Text = view.PosY.ToString();
        }

        private void btnHint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			_pointViewList[App.GameMainViewModel.CorrectWordIndex[GameConstants.CURRENT_ID]].HintAnimation.Begin();
			_pointViewList[App.GameMainViewModel.CorrectWordIndex[GameConstants.CURRENT_ID]].HintAnimation.FillBehavior = FillBehavior.Stop;
        }	
		
		public List<PointView> PointViewList{
			get{
				return _pointViewList;
			}
			set{
				_pointViewList = value;
			}
		}

		private void SuccessAnimation_Completed(object sender, System.EventArgs e)
		{
			this.btnNext.Visibility = Visibility.Visible;
		}

		private void btnNext_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GameConstants.CURRENT_LEVEL++;
			if (GameConstants.CURRENT_LEVEL > GameConstants.MAX_LEVEL){
				GameConstants.CURRENT_LEVEL = 1;        		
			}
			this.LoadDataFromViewModel();
			this.btnNext.Visibility = Visibility.Collapsed;
		}
		
    }
}