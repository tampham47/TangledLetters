using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Minim {
    public partial class PointView : UserControl {
        private DispatcherTimer t;

        public static readonly DependencyProperty posX;
        public double PosX {
            set { SetValue(posX, value); }
            get { return (double)GetValue(posX); }
        }

        public static readonly DependencyProperty posY;
        public double PosY {
            set { SetValue(posY, value); }
            get { return (double)GetValue(posY); }
        }

        static PointView() {
            PropertyMetadata metadata = new PropertyMetadata(new double(), null);

            posX = DependencyProperty.Register("PosX", typeof(double), typeof(PointView), metadata);
            posY = DependencyProperty.Register("PosY", typeof(double), typeof(PointView), metadata);
        }

        public PointView() {
            InitializeComponent();
            this.dragFinishedBehavior.DragFinished += new System.Windows.Input.MouseEventHandler(dragFinishedBehavior_DragFinished);

            StaticAnimation.RepeatBehavior = RepeatBehavior.Forever;
            StaticAnimation.Begin();
        }




        private void dragFinishedBehavior_Dragging(object sender, System.Windows.Input.MouseEventArgs e) {
            this.PosX = (this.RenderTransform as CompositeTransform).TranslateX;
            this.PosY = (this.RenderTransform as CompositeTransform).TranslateY;
        }
		
		private void dragFinishedBehavior_DraggingDisabled(object sender, System.Windows.Input.MouseEventArgs e) {
            (this.RenderTransform as CompositeTransform).TranslateX = this.PosX;
			(this.RenderTransform as CompositeTransform).TranslateY = this.PosY;
        }

        private void UserControl_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            this.Focus();
        }

        private void UserControl_Hold(object sender, System.Windows.Input.GestureEventArgs e) {
            this.Focus();
        }

        private void UserControl_GotFocus(object sender, System.Windows.RoutedEventArgs e) {
            StaticAnimation.Stop();
            FocusAnimation.Begin();
        }

        private void UserControl_LostFocus(object sender, System.Windows.RoutedEventArgs e) {
            FocusAnimation.Stop();
            BackToNormal.Begin();
            StaticAnimation.Begin();
        }

        private void UserControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
            this.Focus();
        }

        private void dragFinishedBehavior_DragFinished(object sender, System.Windows.Input.MouseEventArgs e) {

        }

        public void DropThis() {
            this.DropAnimation.FillBehavior = FillBehavior.HoldEnd;
            this.DropAnimation.Begin();
        }
		
		public void SetUseDragable(bool status){
			if (status){
				this.dragFinishedBehavior.Dragging -= dragFinishedBehavior_DraggingDisabled;
				this.dragFinishedBehavior.Dragging += new System.Windows.Input.MouseEventHandler(dragFinishedBehavior_Dragging);
			}else{
				this.dragFinishedBehavior.Dragging -= dragFinishedBehavior_Dragging;
				this.dragFinishedBehavior.Dragging += new System.Windows.Input.MouseEventHandler(dragFinishedBehavior_DraggingDisabled);
			}
		}
    }
}