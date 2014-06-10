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
using Microsoft.Phone.Shell;

namespace Minim {
    public partial class GameSelectLevel : PhoneApplicationPage {
        public GameSelectLevel() {
            InitializeComponent();
            this.DataContext = App.PictureList;
            if (!App.PictureList.IsDataLoaded) {
                App.PictureList.LoadData();
            }            
        }

        private void imgListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            NavigationService.Navigate(new Uri("/GameScreens/GamePlay.xaml?selectedItem=" + imgListView.SelectedIndex, UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedTo(e);

        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e) {
            base.OnNavigatedFrom(e);

        }
    }
}
