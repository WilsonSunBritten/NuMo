using System.Diagnostics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NuMo
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();


		}

		public async void fillIn(object sender, EventArgs e)
		{
			//error string
			String needed = "Please enter: ";

			//check to see if necessary fields have been input
			if (this.FindByName<Picker>("settings_gender").SelectedIndex == -1)
			{
				needed += "\nGender";
			}


			if (this.FindByName<EntryCell>("settings_name").Text.Equals("Name: "))
			{
				needed += "\nName";
			}


			if (this.FindByName<EntryCell>("settings_age").Text.Equals("Age: "))
			{
				needed += "\nAge";
			}


			if (this.FindByName<EntryCell>("settings_weight").Text.Equals("Weight(lbs): "))
			{
				needed += "\nWeight(lbs)";
			}


			if (this.FindByName<EntryCell>("settings_feet").Text.Equals("Feet: "))
			{
				needed += "\nHeight(feet)";
			}


			if (this.FindByName<EntryCell>("settings_inches").Text.Equals("Inches: "))
			{
				needed += "\nHeight(inches)";
			}


			//if everything has been input, go back to the main page
			if (needed.Equals("Please enter: ")){
				App.Current.MainPage = new MainPage();
			}
			//display the error message
			else {
				await DisplayAlert("Error", needed, "OK");


			}
		}
	}
}
