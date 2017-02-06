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
			//load the saved settings 
			//(for now just ones for DRI)	

			//name
			if (Application.Current.Properties.ContainsKey("dri_name"))
			{
				this.FindByName<EntryCell>("settings_name").Text = Application.Current.Properties["dri_name"] as String;
			}

			//age
			if (Application.Current.Properties.ContainsKey("dri_age"))
			{
				this.FindByName<EntryCell>("settings_age").Text = Application.Current.Properties["dri_age"] as String;
			}

			//gender
			if (Application.Current.Properties.ContainsKey("dri_gender"))
			{
				String gender = Application.Current.Properties["dri_gender"] as String;
				//male
				if (gender.Equals("1"))
				{
					this.FindByName<Picker>("settings_gender").SelectedIndex = 1;
				}
				//female 0
				else {
					this.FindByName<Picker>("settings_gender").SelectedIndex = 0;
				}

			}

			//pregnant? 1 true 0 false
			if (Application.Current.Properties.ContainsKey("dri_pregnant"))
			{
				if ((Application.Current.Properties["dri_pregnant"] as String) == "1")
				{
					this.FindByName<SwitchCell>("settings_pregnant").On = true;
				}
				else {
					this.FindByName<SwitchCell>("settings_pregnant").On = false;
				}
			}


			//lactating? 1 true 0 false
			if (Application.Current.Properties.ContainsKey("dri_lactating"))
			{
				if ((Application.Current.Properties["dri_lactating"] as String) == "1")
				{
					this.FindByName<SwitchCell>("settings_lactating").On = true;
				}
				else {
					this.FindByName<SwitchCell>("settings_lactating").On = false;
				}
			}
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
				//save the info
				Application.Current.Properties["dri_name"] = this.FindByName<EntryCell>("settings_name").Text;
				Application.Current.Properties["dri_age"] = this.FindByName<EntryCell>("settings_age").Text;
				String gender = "0";
				if (this.FindByName<Picker>("settings_gender").SelectedIndex == 1)
				{
					gender = "1";
				}
				Application.Current.Properties["dri_gender"] = gender;

				if (this.FindByName<SwitchCell>("settings_pregnant").On == true)
				{
					Application.Current.Properties["dri_pregnant"] = "1";
				}
				else {
					Application.Current.Properties["dri_pregnant"] = "0";
				}

				if (this.FindByName<SwitchCell>("settings_lactating").On == true)
				{
					Application.Current.Properties["dri_lactating"] = "1";
				}
				else {
					Application.Current.Properties["dri_lactating"] = "0";
				}




				App.Current.MainPage = new MainPage();
			}
			//display the error message
			else {
				await DisplayAlert("Error", needed, "OK");


			}
		}
	}
}
