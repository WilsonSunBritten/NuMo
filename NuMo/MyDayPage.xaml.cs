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
    }
}
