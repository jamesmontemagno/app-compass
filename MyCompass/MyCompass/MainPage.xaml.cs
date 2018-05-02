using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MyCompass
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
           
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MyCompassViewModel)BindingContext).StartCommand.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((MyCompassViewModel)BindingContext).StopCommand.Execute(null);
        }

    }

   
}
