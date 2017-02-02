using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace NuMo
{
	public partial class CreateRecipePage : ContentPage
	{
		public CreateRecipePage()
		{
			InitializeComponent();
		}

		async void OnAddIngredient(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			var selection = await DisplayAlert("Add Ingredient",
				"The button '" + button.Text + "' has been clicked",
				"Search", "Cancel");
			if (selection == true)
			{
				//search for the food...do something
				Debug.WriteLine("YAY LETS GO: " + selection);

			}
		}
	}
}
