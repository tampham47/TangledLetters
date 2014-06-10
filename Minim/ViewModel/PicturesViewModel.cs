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

namespace Minim
{
	public class PicturesViewModel : BaseGameScreenViewModel
	{
		public PicturesViewModel()
		{
			_imageList = new List<ImageSource>();
			IsDataLoaded = false;
		}
		
		public override void LoadData(){
			ImageSource src;
			
			//Level1
			src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/Red-Flower-icon.png", UriKind.Relative));
			_imageList.Add(src);
			
			//Level2
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/Pencil.png", UriKind.Relative));
			_imageList.Add(src);
			
			//Level3
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/dolphin_icon.png", UriKind.Relative));
			_imageList.Add(src);

            //Level4
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/success.png", UriKind.Relative));
            _imageList.Add(src);

            //Level5
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/cloudy-day-icon.png", UriKind.Relative));
            _imageList.Add(src);

            //Level6
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/mobile.png", UriKind.Relative));
            _imageList.Add(src);

            //Level7
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/School.png", UriKind.Relative));
            _imageList.Add(src);

            //Level8
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/Earth.png", UriKind.Relative));
            _imageList.Add(src);

            //Level9
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/glasses_icon.png", UriKind.Relative));
            _imageList.Add(src);

            //Level10
            src = new BitmapImage(new Uri("/Minim;component/Resources/LevelIcon/Student.png", UriKind.Relative));
            _imageList.Add(src);
			
			IsDataLoaded = true;
			
		}
		
		private List<ImageSource> _imageList;
		
		public List<ImageSource> ImageList{
			get{
				return _imageList;
			}
			set{
				_imageList = value;
				NotifyPropertyChanged("ImageList");
			}
		}
	}
}