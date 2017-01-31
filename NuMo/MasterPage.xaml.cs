using System;
using System.Collections.Generic;


using Xamarin.Forms;

namespace NuMo
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterPage()
		{
			InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "My Day",
				IconSource = "ic_today_black_24dp.png",
				TargetType = typeof(MyDayPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Add Item",
				IconSource = "ic_restaurant_black_24dp.png",
				TargetType = typeof(AddItemPage)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Create Food",
				IconSource = "ic_shopping_basket_black_24dp.png",
				TargetType = typeof(CreateFoodPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Settings",
				IconSource = "ic_settings_black_24dp.png",
				TargetType = typeof(SettingsPage)
			});


			listView.ItemsSource = masterPageItems;
		}
	}
}
