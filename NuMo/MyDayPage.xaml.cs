using System;
using System.Collections.Generic;


using Xamarin.Forms;

namespace NuMo
{
	public partial class MyDayPage : ContentPage
	{
        int clickTotal = 0;

        public MyDayPage()
		{
			InitializeComponent();

        }

		void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{

		}
		void OnItemsClicked(object sender, EventArgs args)
		{
            clickTotal += 1;
            items.Text = String.Format("{0} button click{1}",
                                       clickTotal, clickTotal == 1 ? "" : "s");
        }
        void OnNutrientsClicked(object sender, EventArgs args)
        {
            clickTotal += 1;
            items.Text = String.Format("{0} button click{1}",
                                       clickTotal, clickTotal == 1 ? "" : "s");
        }
        void switcher_Toggled(object sender, ToggledEventArgs e)
		{
			//           label.Text = String.Format("Switch is now {0}", e.Value);
		}

        //  protected override async void onappearing()
        //{
        //	//to only show the startup message the first time the app is opened
        //	if (application.current.properties.containskey("start_up"))
        //	{
        //		application.current.properties["start_up"] = "false";
        //	}
        //	else {

        //		application.current.properties["start_up"] = "true";

        //		await displayalert("welcome to numo", "long welcome message here" +
        //		                   " numo is the bestest thing ever you should use it" +
        //		                   " be healthy and live forever  " +
        //		                   " omega omega fatts. this is such a cool app\n"+
        //					   "please fill in user settings", "ok");


        //		app.current.mainpage = new settingspage();

        //	}

        //}


    }
}
