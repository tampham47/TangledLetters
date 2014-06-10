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
using System.Windows.Media;

namespace Minim
{
    public partial class GamePlay : PhoneApplicationPage {
        public GamePlay() {
            InitializeComponent();
            
            this.Loaded += new System.Windows.RoutedEventHandler(MainPage_Loaded);            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
			string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                GameConstants.CURRENT_LEVEL = Int32.Parse(selectedIndex) + 1;
				this.gameMainView.LoadDataFromViewModel();
            }           
        }


        private void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e) {
            //this.DataContext = App.GameMainViewModel;
        }

        private void ApplicationBarIconButton_Click(object sender, System.EventArgs e) {
            if (GameConstants.CURRENT_ID < App.GameMainViewModel.CorrectWordIndex.Count) {
                int index = App.GameMainViewModel.CorrectWordIndex[GameConstants.CURRENT_ID];
                if (index < 0) {
                    for (int i = 0; i < App.GameMainViewModel.AmbigiousConfusingLetter.Count; i++) {
                        if (index == App.GameMainViewModel.AmbigiousConfusingLetter[i] &&
                            !App.GameMainViewModel.AlreadyLetter.Contains(App.GameMainViewModel.AmbigiousLetter[i])) {

                                index = App.GameMainViewModel.AmbigiousLetter[i];
                                break;
                        }
                    }
                }
                this.gameMainView.PointViewList[index].HintAnimation.Begin();
                this.gameMainView.PointViewList[index].HintAnimation.FillBehavior = FillBehavior.Stop;
            }
        }

        private void b2_Click(object sender, System.EventArgs e) {
            this.gameMainView.LoadDataFromViewModel();
        }

        private void b3_Click(object sender, System.EventArgs e) {
            NavigationService.GoBack();
        }

        private void b4_Click(object sender, System.EventArgs e)
        {
			GameConstants.CURRENT_LEVEL++;
			if (GameConstants.CURRENT_LEVEL > GameConstants.MAX_LEVEL){
				GameConstants.CURRENT_LEVEL = 1;        		
			}
			this.gameMainView.LoadDataFromViewModel();          
		}			       
    }
}
