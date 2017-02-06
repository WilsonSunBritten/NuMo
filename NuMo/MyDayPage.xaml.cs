using System;
using System.Collections.Generic;


using Xamarin.Forms;

namespace NuMo
{
	public partial class MyDayPage : ContentPage
	{
		public MyDayPage()
		{
			InitializeComponent();

		}

		void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{

		}
		void OnButtonClicked(object sender, EventArgs args)
		{

		}
		void switcher_Toggled(object sender, ToggledEventArgs e)
		{
			//           label.Text = String.Format("Switch is now {0}", e.Value);
		}
	

		protected override async void OnAppearing()
		{
			//to only show the startup message the first time the app is opened
			if (Application.Current.Properties.ContainsKey("start_up"))
			{
				Application.Current.Properties["start_up"] = "false";
			}
			else {

				Application.Current.Properties["start_up"] = "true";

				await DisplayAlert("Welcome to NuMo", "LONG WELCOME MESSAGE HERE" +
				                   " NUMO IS THE BESTEST THING EVER YOU SHOULD USE IT" +
				                   " BE HEALTHY AND LIVE FOREVER  " +
				                   " OMEGA OMEGA FATTS. THIS IS SUCH A COOL APP\n"+
							   "Please fill in user settings", "OK");


				App.Current.MainPage = new SettingsPage();

			}

		}


	}
}
