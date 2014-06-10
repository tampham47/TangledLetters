using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Threading;

namespace Minim {
    public partial class ConnectorView : UserControl {       

        public static readonly DependencyProperty posX1;
        public double PosX1 {
            set { SetValue(posX1, value); }
            get { return (double)GetValue(posX1); }
        }

        public static readonly DependencyProperty posX2;
        public double PosX2 {
            set { SetValue(posX2, value); }
            get { return (double)GetValue(posX2); }
        }

        public static readonly DependencyProperty posY1;
        public double PosY1 {
            set { SetValue(posY1, value); }
            get { return (double)GetValue(posY1); }
        }

        public static readonly DependencyProperty posY2;
        public double PosY2 {
            set { SetValue(posY2, value); }
            get { return (double)GetValue(posY2); }
        }

        static ConnectorView() {
            PropertyMetadata metadata = new PropertyMetadata(new double(), null);

            posX1 = DependencyProperty.Register("PosX1", typeof(double), typeof(ConnectorView), metadata);
            posX2 = DependencyProperty.Register("PosX2", typeof(double), typeof(ConnectorView), metadata);
            posY1 = DependencyProperty.Register("PosY1", typeof(double), typeof(ConnectorView), metadata);
            posY2 = DependencyProperty.Register("PosY2", typeof(double), typeof(ConnectorView), metadata);
        }

        public ConnectorView() {
            // Required to initialize variables
            InitializeComponent();
        }     
    }

    public class ToCenter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (targetType == typeof(double) && value.GetType() == typeof(double)) {
                return ((double)value + 100 / 2 + 0.5d);
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (targetType == typeof(double) && value.GetType() == typeof(double)) {
                return ((double)value + 100 / 2 + 0.5d);
            }
            return value;
        }
    }
}