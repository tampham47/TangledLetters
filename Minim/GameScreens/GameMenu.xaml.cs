using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace Minim {
    public partial class GameMenu : PhoneApplicationPage {
        public GameMenu() {
            InitializeComponent();         
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {            
            base.OnNavigatedTo(e);
            
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedFrom(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate(new Uri("/GameScreens/GameSelectLevel.xaml?selectedItem=", UriKind.Relative));
        }
        private void Button1_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate(new Uri("/GameScreens/GameInstruction.xaml", UriKind.Relative));
        }
        private void Button2_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
