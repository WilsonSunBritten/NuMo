using System;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Forms;

//Calculations based off of Holly's provided DRI sheet

//Need to add some kind of "else" message if none of the categories match?

namespace NuMo
{
	public partial class DRIPage : ContentPage
	{
		private int ageNum;
		private int gender; //0=female, 1=male
		private int pregnant; //0=false, 1=true
		private int lactating; //0=false, 1=true


		public DRIPage()
		{
			InitializeComponent();
			setValues();

		}

		//reset values to the recommended DRI values pre-populated by the page
		public async void reset(object sender, EventArgs e)
		{
			var selection = await DisplayAlert("Reset?", "Are you sure you want to reset your dietary intake to the recommended values?", "Yes", "No");
			if (selection == true)
			{
				//set as not customized
				Application.Current.Properties["custom_dri"] = "false";
				//populate fields
				setValues();
			}
		}

		//info message about the page
		public async void question(object sender, EventArgs e)
		{
			await DisplayAlert("Help", "Helpful message about the page", "OK");

		}

		//allow the user to change the recommended DRI values
		public async void customize(object sender, EventArgs e)
		{
			var selection = await DisplayAlert("Customize?", "Are you sure you want to customize your recommended dietary intake?", "Yes", "No");
			if (selection == true)
			{
				//set as customized
				Application.Current.Properties["custom_dri"] = "true";
				//save all of the custom values
				Application.Current.Properties["dri_calcium"] = this.FindByName<Entry>("dri_calcium").Text;
				Application.Current.Properties["dri_carboyhydrates"] = this.FindByName<Entry>("dri_carbohydrates").Text;
				Application.Current.Properties["dri_protein"] = this.FindByName<Entry>("dri_protein").Text;
				Application.Current.Properties["dri_vitaminA"] = this.FindByName<Entry>("dri_vitaminA").Text;
				Application.Current.Properties["dri_vitaminC"] = this.FindByName<Entry>("dri_vitaminC").Text;
				Application.Current.Properties["dri_vitaminD"] = this.FindByName<Entry>("dri_vitaminD").Text;
				Application.Current.Properties["dri_vitaminE"] = this.FindByName<Entry>("dri_vitaminE").Text;
				Application.Current.Properties["dri_thiamin"] = this.FindByName<Entry>("dri_thiamin").Text;
				Application.Current.Properties["dri_riboflavin"] =this.FindByName<Entry>("dri_riboflavin").Text;
				Application.Current.Properties["dri_niacin"] = this.FindByName<Entry>("dri_niacin").Text;
				Application.Current.Properties["dri_vitaminB6"] = this.FindByName<Entry>("dri_vitaminB6").Text;
				Application.Current.Properties["dri_folate"] = this.FindByName<Entry>("dri_folate").Text;
				Application.Current.Properties["dri_vitaminB12"] = this.FindByName<Entry>("dri_vitaminB12").Text;
				Application.Current.Properties["dri_copper"] = this.FindByName<Entry>("dri_copper").Text;
				Application.Current.Properties["dri_iodine"] = this.FindByName<Entry>("dri_iodine").Text;
				Application.Current.Properties["dri_iron"] = this.FindByName<Entry>("dri_iron").Text;
				Application.Current.Properties["dri_magnesium"] = this.FindByName<Entry>("dri_magnesium").Text;
				Application.Current.Properties["dri_molybdenum"] =this.FindByName<Entry>("dri_molybdenum").Text;
				Application.Current.Properties["dri_phosphorus"] =this.FindByName<Entry>("dri_phosphorus").Text;
				Application.Current.Properties["dri_selenium"] =this.FindByName<Entry>("dri_selenium").Text;
				Application.Current.Properties["dri_zinc"] =this.FindByName<Entry>("dri_zinc").Text;
			}
		}

		//for code reuse
		public void setValuesHelper()
		{
			//4 values needed to calculate DRI
			String age = Application.Current.Properties["dri_age"] as String;
			//because "age: " is automatically in front
			if (age.Length < 7)             //one digit age
			{
				age = age.Substring(5, 1);
			}
			else {                          //2 digit age
				age = age.Substring(5, 2);
			}

			ageNum = int.Parse(age);

			String genderString = Application.Current.Properties["dri_gender"] as String;
			gender = int.Parse(genderString);

			String pregnantString = Application.Current.Properties["dri_pregnant"] as String;
			pregnant = int.Parse(pregnantString);

			String lactatingString = Application.Current.Properties["dri_lactating"] as String;
			lactating = int.Parse(lactatingString);

			//calculations for infants
			if (ageNum < 1)
			{
				this.FindByName<Entry>("dri_calcium").Text = "";
				this.FindByName<Entry>("dri_carbohydrates").Text = "";
				this.FindByName<Entry>("dri_protein").Text = "1";
				this.FindByName<Entry>("dri_vitaminA").Text = "";
				this.FindByName<Entry>("dri_vitaminC").Text = "";
				this.FindByName<Entry>("dri_vitaminD").Text = "";
				this.FindByName<Entry>("dri_vitaminE").Text = "";
				this.FindByName<Entry>("dri_thiamin").Text = "";
				this.FindByName<Entry>("dri_riboflavin").Text = "";
				this.FindByName<Entry>("dri_niacin").Text = "";
				this.FindByName<Entry>("dri_vitaminB6").Text = "";
				this.FindByName<Entry>("dri_folate").Text = "";
				this.FindByName<Entry>("dri_vitaminB12").Text = "";
				this.FindByName<Entry>("dri_copper").Text = "";
				this.FindByName<Entry>("dri_iodine").Text = "";
				this.FindByName<Entry>("dri_iron").Text = "6.9";
				this.FindByName<Entry>("dri_magnesium").Text = "";
				this.FindByName<Entry>("dri_molybdenum").Text = "";
				this.FindByName<Entry>("dri_phosphorus").Text = "";
				this.FindByName<Entry>("dri_selenium").Text = "";
				this.FindByName<Entry>("dri_zinc").Text = "2.5";
			}

			//Calculations for Children
			else if (ageNum >= 1 && ageNum <= 3)
			{
				this.FindByName<Entry>("dri_calcium").Text = "500";
				this.FindByName<Entry>("dri_carbohydrates").Text = "100";
				this.FindByName<Entry>("dri_protein").Text = ".87";
				this.FindByName<Entry>("dri_vitaminA").Text = "210";
				this.FindByName<Entry>("dri_vitaminC").Text = "13";
				this.FindByName<Entry>("dri_vitaminD").Text = "10";
				this.FindByName<Entry>("dri_vitaminE").Text = "5";
				this.FindByName<Entry>("dri_thiamin").Text = ".4";
				this.FindByName<Entry>("dri_riboflavin").Text = ".4";
				this.FindByName<Entry>("dri_niacin").Text = "5";
				this.FindByName<Entry>("dri_vitaminB6").Text = ".4";
				this.FindByName<Entry>("dri_folate").Text = "120";
				this.FindByName<Entry>("dri_vitaminB12").Text = ".7";
				this.FindByName<Entry>("dri_copper").Text = "260";
				this.FindByName<Entry>("dri_iodine").Text = "65";
				this.FindByName<Entry>("dri_iron").Text = "3";
				this.FindByName<Entry>("dri_magnesium").Text = "65";
				this.FindByName<Entry>("dri_molybdenum").Text = "13";
				this.FindByName<Entry>("dri_phosphorus").Text = "380";
				this.FindByName<Entry>("dri_selenium").Text = "17";
				this.FindByName<Entry>("dri_zinc").Text = "2.5";
			}
			//calculations for older children
			else if (ageNum >= 4 && ageNum <= 8)
			{
				this.FindByName<Entry>("dri_calcium").Text = "800";
				this.FindByName<Entry>("dri_carbohydrates").Text = "100";
				this.FindByName<Entry>("dri_protein").Text = ".76";
				this.FindByName<Entry>("dri_vitaminA").Text = "275";
				this.FindByName<Entry>("dri_vitaminC").Text = "22";
				this.FindByName<Entry>("dri_vitaminD").Text = "10";
				this.FindByName<Entry>("dri_vitaminE").Text = "6";
				this.FindByName<Entry>("dri_thiamin").Text = ".5";
				this.FindByName<Entry>("dri_riboflavin").Text = ".5";
				this.FindByName<Entry>("dri_niacin").Text = "6";
				this.FindByName<Entry>("dri_vitaminB6").Text = ".5";
				this.FindByName<Entry>("dri_folate").Text = "160";
				this.FindByName<Entry>("dri_vitaminB12").Text = "1";
				this.FindByName<Entry>("dri_copper").Text = "340";
				this.FindByName<Entry>("dri_iodine").Text = "65";
				this.FindByName<Entry>("dri_iron").Text = "4.1";
				this.FindByName<Entry>("dri_magnesium").Text = "110";
				this.FindByName<Entry>("dri_molybdenum").Text = "17";
				this.FindByName<Entry>("dri_phosphorus").Text = "405";
				this.FindByName<Entry>("dri_selenium").Text = "23";
				this.FindByName<Entry>("dri_zinc").Text = "4";

			}
			//calculations for adults
			else {
				//Males
				if (gender == 1)
				{
					//9-13
					if (ageNum >= 9 && ageNum <= 13)
					{
						this.FindByName<Entry>("dri_calcium").Text = "1100";
						this.FindByName<Entry>("dri_carbohydrates").Text = "100";
						this.FindByName<Entry>("dri_protein").Text = ".76";
						this.FindByName<Entry>("dri_vitaminA").Text = "445";
						this.FindByName<Entry>("dri_vitaminC").Text = "39";
						this.FindByName<Entry>("dri_vitaminD").Text = "10";
						this.FindByName<Entry>("dri_vitaminE").Text = "9";
						this.FindByName<Entry>("dri_thiamin").Text = ".7";
						this.FindByName<Entry>("dri_riboflavin").Text = ".8";
						this.FindByName<Entry>("dri_niacin").Text = "9";
						this.FindByName<Entry>("dri_vitaminB6").Text = ".8";
						this.FindByName<Entry>("dri_folate").Text = "250";
						this.FindByName<Entry>("dri_vitaminB12").Text = "1.5";
						this.FindByName<Entry>("dri_copper").Text = "540";
						this.FindByName<Entry>("dri_iodine").Text = "73";
						this.FindByName<Entry>("dri_iron").Text = "5.9";
						this.FindByName<Entry>("dri_magnesium").Text = "200";
						this.FindByName<Entry>("dri_molybdenum").Text = "26";
						this.FindByName<Entry>("dri_phosphorus").Text = "1,055";
						this.FindByName<Entry>("dri_selenium").Text = "35";
						this.FindByName<Entry>("dri_zinc").Text = "7";
					}
					//14-18
					else if (ageNum >= 14 && ageNum <= 18)
					{
						this.FindByName<Entry>("dri_calcium").Text = "1100";
						this.FindByName<Entry>("dri_carbohydrates").Text = "100";
						this.FindByName<Entry>("dri_protein").Text = ".73";
						this.FindByName<Entry>("dri_vitaminA").Text = "630";
						this.FindByName<Entry>("dri_vitaminC").Text = "63";
						this.FindByName<Entry>("dri_vitaminD").Text = "10";
						this.FindByName<Entry>("dri_vitaminE").Text = "12";
						this.FindByName<Entry>("dri_thiamin").Text = "1";
						this.FindByName<Entry>("dri_riboflavin").Text = "1.1";
						this.FindByName<Entry>("dri_niacin").Text = "12";
						this.FindByName<Entry>("dri_vitaminB6").Text = "1.1";
						this.FindByName<Entry>("dri_folate").Text = "330";
						this.FindByName<Entry>("dri_vitaminB12").Text = "2";
						this.FindByName<Entry>("dri_copper").Text = "685";
						this.FindByName<Entry>("dri_iodine").Text = "95";
						this.FindByName<Entry>("dri_iron").Text = "7.7";
						this.FindByName<Entry>("dri_magnesium").Text = "340";
						this.FindByName<Entry>("dri_molybdenum").Text = "33";
						this.FindByName<Entry>("dri_phosphorus").Text = "1055";
						this.FindByName<Entry>("dri_selenium").Text = "45";
						this.FindByName<Entry>("dri_zinc").Text = "8.5";
					}
					//19-30
					else if (ageNum >= 19 && ageNum <= 30)
					{
						this.FindByName<Entry>("dri_calcium").Text = "800";
						this.FindByName<Entry>("dri_carbohydrates").Text = "100";
						this.FindByName<Entry>("dri_protein").Text = ".66";
						this.FindByName<Entry>("dri_vitaminA").Text = "625";
						this.FindByName<Entry>("dri_vitaminC").Text = "75";
						this.FindByName<Entry>("dri_vitaminD").Text = "10";
						this.FindByName<Entry>("dri_vitaminE").Text = "12";
						this.FindByName<Entry>("dri_thiamin").Text = "1";
						this.FindByName<Entry>("dri_riboflavin").Text = "1.1";
						this.FindByName<Entry>("dri_niacin").Text = "12";
						this.FindByName<Entry>("dri_vitaminB6").Text = "1.1";
						this.FindByName<Entry>("dri_folate").Text = "320";
						this.FindByName<Entry>("dri_vitaminB12").Text = "2";
						this.FindByName<Entry>("dri_copper").Text = "700";
						this.FindByName<Entry>("dri_iodine").Text = "95";
						this.FindByName<Entry>("dri_iron").Text = "6";
						this.FindByName<Entry>("dri_magnesium").Text = "330";
						this.FindByName<Entry>("dri_molybdenum").Text = "34";
						this.FindByName<Entry>("dri_phosphorus").Text = "580";
						this.FindByName<Entry>("dri_selenium").Text = "45";
						this.FindByName<Entry>("dri_zinc").Text = "9.4";
					}
					//31-50
					else if (ageNum >= 31 && ageNum <= 50)
					{
						this.FindByName<Entry>("dri_calcium").Text = "800";
						this.FindByName<Entry>("dri_carbohydrates").Text = "100";
						this.FindByName<Entry>("dri_protein").Text = ".66";
						this.FindByName<Entry>("dri_vitaminA").Text = "625";
						this.FindByName<Entry>("dri_vitaminC").Text = "75";
						this.FindByName<Entry>("dri_vitaminD").Text = "10";
						this.FindByName<Entry>("dri_vitaminE").Text = "12";
						this.FindByName<Entry>("dri_thiamin").Text = "1";
						this.FindByName<Entry>("dri_riboflavin").Text = "1.1";
						this.FindByName<Entry>("dri_niacin").Text = "12";
						this.FindByName<Entry>("dri_vitaminB6").Text = "1.1";
						this.FindByName<Entry>("dri_folate").Text = "320";
						this.FindByName<Entry>("dri_vitaminB12").Text = "2";
						this.FindByName<Entry>("dri_copper").Text = "700";
						this.FindByName<Entry>("dri_iodine").Text = "95";
						this.FindByName<Entry>("dri_iron").Text = "6";
						this.FindByName<Entry>("dri_magnesium").Text = "350";
						this.FindByName<Entry>("dri_molybdenum").Text = "34";
						this.FindByName<Entry>("dri_phosphorus").Text = "580";
						this.FindByName<Entry>("dri_selenium").Text = "45";
						this.FindByName<Entry>("dri_zinc").Text = "9.4";
					}
					//51-70
					else if (ageNum >= 51 && ageNum <= 70)
					{
						this.FindByName<Entry>("dri_calcium").Text = "800";
						this.FindByName<Entry>("dri_carbohydrates").Text = "100";
						this.FindByName<Entry>("dri_protein").Text = ".66";
						this.FindByName<Entry>("dri_vitaminA").Text = "625";
						this.FindByName<Entry>("dri_vitaminC").Text = "75";
						this.FindByName<Entry>("dri_vitaminD").Text = "10";
						this.FindByName<Entry>("dri_vitaminE").Text = "12";
						this.FindByName<Entry>("dri_thiamin").Text = "1";
						this.FindByName<Entry>("dri_riboflavin").Text = "1.1";
						this.FindByName<Entry>("dri_niacin").Text = "12";
						this.FindByName<Entry>("dri_vitaminB6").Text = "1.4";
						this.FindByName<Entry>("dri_folate").Text = "320";
						this.FindByName<Entry>("dri_vitaminB12").Text = "2";
						this.FindByName<Entry>("dri_copper").Text = "700";
						this.FindByName<Entry>("dri_iodine").Text = "95";
						this.FindByName<Entry>("dri_iron").Text = "6";
						this.FindByName<Entry>("dri_magnesium").Text = "350";
						this.FindByName<Entry>("dri_molybdenum").Text = "34";
						this.FindByName<Entry>("dri_phosphorus").Text = "580";
						this.FindByName<Entry>("dri_selenium").Text = "45";
						this.FindByName<Entry>("dri_zinc").Text = "9.4";
					}
					//70+
					else if (ageNum > 70)
					{
						this.FindByName<Entry>("dri_calcium").Text = "1000";
						this.FindByName<Entry>("dri_carbohydrates").Text = "100";
						this.FindByName<Entry>("dri_protein").Text = ".66";
						this.FindByName<Entry>("dri_vitaminA").Text = "625";
						this.FindByName<Entry>("dri_vitaminC").Text = "75";
						this.FindByName<Entry>("dri_vitaminD").Text = "10";
						this.FindByName<Entry>("dri_vitaminE").Text = "12";
						this.FindByName<Entry>("dri_thiamin").Text = "1";
						this.FindByName<Entry>("dri_riboflavin").Text = "1.1";
						this.FindByName<Entry>("dri_niacin").Text = "12";
						this.FindByName<Entry>("dri_vitaminB6").Text = "1.4";
						this.FindByName<Entry>("dri_folate").Text = "320";
						this.FindByName<Entry>("dri_vitaminB12").Text = "2";
						this.FindByName<Entry>("dri_copper").Text = "700";
						this.FindByName<Entry>("dri_iodine").Text = "95";
						this.FindByName<Entry>("dri_iron").Text = "6";
						this.FindByName<Entry>("dri_magnesium").Text = "350";
						this.FindByName<Entry>("dri_molybdenum").Text = "34";
						this.FindByName<Entry>("dri_phosphorus").Text = "580";
						this.FindByName<Entry>("dri_selenium").Text = "45";
						this.FindByName<Entry>("dri_zinc").Text = "9.4";
					}
				}
				//female
				else if (gender == 0)
				{
					//not pregnant or lactating
					if (pregnant == 0 && lactating == 0)
					{
						//9-13
						if (ageNum >= 9 && ageNum <= 13)
						{
							this.FindByName<Entry>("dri_calcium").Text = "1100";
							this.FindByName<Entry>("dri_carbohydrates").Text = "100";
							this.FindByName<Entry>("dri_protein").Text = ".76";
							this.FindByName<Entry>("dri_vitaminA").Text = "420";
							this.FindByName<Entry>("dri_vitaminC").Text = "39";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "9";
							this.FindByName<Entry>("dri_thiamin").Text = ".7";
							this.FindByName<Entry>("dri_riboflavin").Text = ".8";
							this.FindByName<Entry>("dri_niacin").Text = "9";
							this.FindByName<Entry>("dri_vitaminB6").Text = ".8";
							this.FindByName<Entry>("dri_folate").Text = "250";
							this.FindByName<Entry>("dri_vitaminB12").Text = "1.5";
							this.FindByName<Entry>("dri_copper").Text = "540";
							this.FindByName<Entry>("dri_iodine").Text = "73";
							this.FindByName<Entry>("dri_iron").Text = "5.7";
							this.FindByName<Entry>("dri_magnesium").Text = "200";
							this.FindByName<Entry>("dri_molybdenum").Text = "26";
							this.FindByName<Entry>("dri_phosphorus").Text = "1,055";
							this.FindByName<Entry>("dri_selenium").Text = "35";
							this.FindByName<Entry>("dri_zinc").Text = "7";
						}
						//14-18
						else if (ageNum >= 14 && ageNum <= 18)
						{
							this.FindByName<Entry>("dri_calcium").Text = "1100";
							this.FindByName<Entry>("dri_carbohydrates").Text = "100";
							this.FindByName<Entry>("dri_protein").Text = ".71";
							this.FindByName<Entry>("dri_vitaminA").Text = "485";
							this.FindByName<Entry>("dri_vitaminC").Text = "56";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = ".9";
							this.FindByName<Entry>("dri_riboflavin").Text = ".9";
							this.FindByName<Entry>("dri_niacin").Text = "11";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1";
							this.FindByName<Entry>("dri_folate").Text = "330";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2";
							this.FindByName<Entry>("dri_copper").Text = "685";
							this.FindByName<Entry>("dri_iodine").Text = "95";
							this.FindByName<Entry>("dri_iron").Text = "7.9";
							this.FindByName<Entry>("dri_magnesium").Text = "300";
							this.FindByName<Entry>("dri_molybdenum").Text = "33";
							this.FindByName<Entry>("dri_phosphorus").Text = "1055";
							this.FindByName<Entry>("dri_selenium").Text = "45";
							this.FindByName<Entry>("dri_zinc").Text = "7.3";
						}
						//19-30
						else if (ageNum >= 19 && ageNum <= 30)
						{
							this.FindByName<Entry>("dri_calcium").Text = "800";
							this.FindByName<Entry>("dri_carbohydrates").Text = "100";
							this.FindByName<Entry>("dri_protein").Text = ".66";
							this.FindByName<Entry>("dri_vitaminA").Text = "500";
							this.FindByName<Entry>("dri_vitaminC").Text = "60";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = ".9";
							this.FindByName<Entry>("dri_riboflavin").Text = ".9";
							this.FindByName<Entry>("dri_niacin").Text = "11";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.1";
							this.FindByName<Entry>("dri_folate").Text = "320";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2";
							this.FindByName<Entry>("dri_copper").Text = "700";
							this.FindByName<Entry>("dri_iodine").Text = "95";
							this.FindByName<Entry>("dri_iron").Text = "8.1";
							this.FindByName<Entry>("dri_magnesium").Text = "255";
							this.FindByName<Entry>("dri_molybdenum").Text = "34";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "45";
							this.FindByName<Entry>("dri_zinc").Text = "6.8";
						}

						//31-50
						else if (ageNum >= 31 && ageNum <= 50)
						{
							this.FindByName<Entry>("dri_calcium").Text = "800";
							this.FindByName<Entry>("dri_carbohydrates").Text = "100";
							this.FindByName<Entry>("dri_protein").Text = ".66";
							this.FindByName<Entry>("dri_vitaminA").Text = "500";
							this.FindByName<Entry>("dri_vitaminC").Text = "60";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = ".9";
							this.FindByName<Entry>("dri_riboflavin").Text = ".9";
							this.FindByName<Entry>("dri_niacin").Text = "11";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.1";
							this.FindByName<Entry>("dri_folate").Text = "320";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2";
							this.FindByName<Entry>("dri_copper").Text = "700";
							this.FindByName<Entry>("dri_iodine").Text = "95";
							this.FindByName<Entry>("dri_iron").Text = "8.1";
							this.FindByName<Entry>("dri_magnesium").Text = "265";
							this.FindByName<Entry>("dri_molybdenum").Text = "34";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "45";
							this.FindByName<Entry>("dri_zinc").Text = "6.8";
						}
						//51-70
						else if (ageNum >= 51 && ageNum <= 70)
						{
							this.FindByName<Entry>("dri_calcium").Text = "1000";
							this.FindByName<Entry>("dri_carbohydrates").Text = "100";
							this.FindByName<Entry>("dri_protein").Text = ".66";
							this.FindByName<Entry>("dri_vitaminA").Text = "500";
							this.FindByName<Entry>("dri_vitaminC").Text = "60";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = ".9";
							this.FindByName<Entry>("dri_riboflavin").Text = ".9";
							this.FindByName<Entry>("dri_niacin").Text = "11";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.3";
							this.FindByName<Entry>("dri_folate").Text = "320";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2";
							this.FindByName<Entry>("dri_copper").Text = "700";
							this.FindByName<Entry>("dri_iodine").Text = "95";
							this.FindByName<Entry>("dri_iron").Text = "5";
							this.FindByName<Entry>("dri_magnesium").Text = "265";
							this.FindByName<Entry>("dri_molybdenum").Text = "34";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "45";
							this.FindByName<Entry>("dri_zinc").Text = "6.8";
						}
						//70+
						else if (ageNum > 70)
						{
							this.FindByName<Entry>("dri_calcium").Text = "1000";
							this.FindByName<Entry>("dri_carbohydrates").Text = "100";
							this.FindByName<Entry>("dri_protein").Text = ".66";
							this.FindByName<Entry>("dri_vitaminA").Text = "500";
							this.FindByName<Entry>("dri_vitaminC").Text = "60";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = ".9";
							this.FindByName<Entry>("dri_riboflavin").Text = ".9";
							this.FindByName<Entry>("dri_niacin").Text = "11";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.3";
							this.FindByName<Entry>("dri_folate").Text = "320";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2";
							this.FindByName<Entry>("dri_copper").Text = "700";
							this.FindByName<Entry>("dri_iodine").Text = "95";
							this.FindByName<Entry>("dri_iron").Text = "5";
							this.FindByName<Entry>("dri_magnesium").Text = "265";
							this.FindByName<Entry>("dri_molybdenum").Text = "34";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "45";
							this.FindByName<Entry>("dri_zinc").Text = "6.8";
						}
					}
					//pregnant women
					else if (pregnant == 1 && lactating == 0)
					{
						//14-18
						if (ageNum >= 14 && ageNum <= 18)
						{
							this.FindByName<Entry>("dri_calcium").Text = "1000";
							this.FindByName<Entry>("dri_carbohydrates").Text = "135";
							this.FindByName<Entry>("dri_protein").Text = ".88";
							this.FindByName<Entry>("dri_vitaminA").Text = "530";
							this.FindByName<Entry>("dri_vitaminC").Text = "66";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = "1.2";
							this.FindByName<Entry>("dri_riboflavin").Text = "1.2";
							this.FindByName<Entry>("dri_niacin").Text = "14";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.6";
							this.FindByName<Entry>("dri_folate").Text = "520";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2.2";
							this.FindByName<Entry>("dri_copper").Text = "785";
							this.FindByName<Entry>("dri_iodine").Text = "160";
							this.FindByName<Entry>("dri_iron").Text = "23";
							this.FindByName<Entry>("dri_magnesium").Text = "335";
							this.FindByName<Entry>("dri_molybdenum").Text = "40";
							this.FindByName<Entry>("dri_phosphorus").Text = "1055";
							this.FindByName<Entry>("dri_selenium").Text = "49";
							this.FindByName<Entry>("dri_zinc").Text = "10.5";
						}
						//19-30
						else if (ageNum >= 19 && ageNum <= 30)
						{
							this.FindByName<Entry>("dri_calcium").Text = "800";
							this.FindByName<Entry>("dri_carbohydrates").Text = "135";
							this.FindByName<Entry>("dri_protein").Text = ".88";
							this.FindByName<Entry>("dri_vitaminA").Text = "550";
							this.FindByName<Entry>("dri_vitaminC").Text = "70";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = "1.2";
							this.FindByName<Entry>("dri_riboflavin").Text = "1.2";
							this.FindByName<Entry>("dri_niacin").Text = "14";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.6";
							this.FindByName<Entry>("dri_folate").Text = "520";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2.2";
							this.FindByName<Entry>("dri_copper").Text = "800";
							this.FindByName<Entry>("dri_iodine").Text = "160";
							this.FindByName<Entry>("dri_iron").Text = "22";
							this.FindByName<Entry>("dri_magnesium").Text = "290";
							this.FindByName<Entry>("dri_molybdenum").Text = "40";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "49";
							this.FindByName<Entry>("dri_zinc").Text = "9.5";
						}
						//31-50
						else if (ageNum >= 31 && ageNum <= 50)
						{
							this.FindByName<Entry>("dri_calcium").Text = "800";
							this.FindByName<Entry>("dri_carbohydrates").Text = "135";
							this.FindByName<Entry>("dri_protein").Text = ".88";
							this.FindByName<Entry>("dri_vitaminA").Text = "550";
							this.FindByName<Entry>("dri_vitaminC").Text = "70";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "12";
							this.FindByName<Entry>("dri_thiamin").Text = "1.2";
							this.FindByName<Entry>("dri_riboflavin").Text = "1.2";
							this.FindByName<Entry>("dri_niacin").Text = "14";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.6";
							this.FindByName<Entry>("dri_folate").Text = "520";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2.2";
							this.FindByName<Entry>("dri_copper").Text = "800";
							this.FindByName<Entry>("dri_iodine").Text = "160";
							this.FindByName<Entry>("dri_iron").Text = "22";
							this.FindByName<Entry>("dri_magnesium").Text = "300";
							this.FindByName<Entry>("dri_molybdenum").Text = "40";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "49";
							this.FindByName<Entry>("dri_zinc").Text = "9.5";
						}
					}
					//lactating women
					else if (pregnant == 0 && lactating == 1)
					{
						//14-18
						if (ageNum >= 14 && ageNum <= 18)
						{
							this.FindByName<Entry>("dri_calcium").Text = "1000";
							this.FindByName<Entry>("dri_carbohydrates").Text = "160";
							this.FindByName<Entry>("dri_protein").Text = "1.05";
							this.FindByName<Entry>("dri_vitaminA").Text = "885";
							this.FindByName<Entry>("dri_vitaminC").Text = "96";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "16";
							this.FindByName<Entry>("dri_thiamin").Text = "1.2";
							this.FindByName<Entry>("dri_riboflavin").Text = "1.3";
							this.FindByName<Entry>("dri_niacin").Text = "13";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.7";
							this.FindByName<Entry>("dri_folate").Text = "450";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2.4";
							this.FindByName<Entry>("dri_copper").Text = "985";
							this.FindByName<Entry>("dri_iodine").Text = "209";
							this.FindByName<Entry>("dri_iron").Text = "7";
							this.FindByName<Entry>("dri_magnesium").Text = "300";
							this.FindByName<Entry>("dri_molybdenum").Text = "35";
							this.FindByName<Entry>("dri_phosphorus").Text = "1055";
							this.FindByName<Entry>("dri_selenium").Text = "59";
							this.FindByName<Entry>("dri_zinc").Text = "10.9";
						}
						//19-30
						else if (ageNum >= 19 && ageNum <= 30)
						{
							this.FindByName<Entry>("dri_calcium").Text = "800";
							this.FindByName<Entry>("dri_carbohydrates").Text = "160";
							this.FindByName<Entry>("dri_protein").Text = "1.05";
							this.FindByName<Entry>("dri_vitaminA").Text = "900";
							this.FindByName<Entry>("dri_vitaminC").Text = "100";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "16";
							this.FindByName<Entry>("dri_thiamin").Text = "1.2";
							this.FindByName<Entry>("dri_riboflavin").Text = "1.3";
							this.FindByName<Entry>("dri_niacin").Text = "13";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.7";
							this.FindByName<Entry>("dri_folate").Text = "450";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2.4";
							this.FindByName<Entry>("dri_copper").Text = "1000";
							this.FindByName<Entry>("dri_iodine").Text = "209";
							this.FindByName<Entry>("dri_iron").Text = "6.5";
							this.FindByName<Entry>("dri_magnesium").Text = "255";
							this.FindByName<Entry>("dri_molybdenum").Text = "36";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "59";
							this.FindByName<Entry>("dri_zinc").Text = "10.4";
						}
						//31-50
						else if (ageNum >= 31 && ageNum <= 50)
						{
							this.FindByName<Entry>("dri_calcium").Text = "800";
							this.FindByName<Entry>("dri_carbohydrates").Text = "160";
							this.FindByName<Entry>("dri_protein").Text = "1.05";
							this.FindByName<Entry>("dri_vitaminA").Text = "900";
							this.FindByName<Entry>("dri_vitaminC").Text = "100";
							this.FindByName<Entry>("dri_vitaminD").Text = "10";
							this.FindByName<Entry>("dri_vitaminE").Text = "16";
							this.FindByName<Entry>("dri_thiamin").Text = "1.2";
							this.FindByName<Entry>("dri_riboflavin").Text = "1.3";
							this.FindByName<Entry>("dri_niacin").Text = "13";
							this.FindByName<Entry>("dri_vitaminB6").Text = "1.7";
							this.FindByName<Entry>("dri_folate").Text = "450";
							this.FindByName<Entry>("dri_vitaminB12").Text = "2.4";
							this.FindByName<Entry>("dri_copper").Text = "1000";
							this.FindByName<Entry>("dri_iodine").Text = "209";
							this.FindByName<Entry>("dri_iron").Text = "6.5";
							this.FindByName<Entry>("dri_magnesium").Text = "265";
							this.FindByName<Entry>("dri_molybdenum").Text = "36";
							this.FindByName<Entry>("dri_phosphorus").Text = "580";
							this.FindByName<Entry>("dri_selenium").Text = "59";
							this.FindByName<Entry>("dri_zinc").Text = "10.4";
						}
					}

				}

			}
		}



		//pull up the saved customized values, or auto-populate recommended values
		public void setValues()
		{
			if (Application.Current.Properties.ContainsKey("custom_dri"))
			{
				//if it is custom
				if (Application.Current.Properties["custom_dri"].Equals("true"))
				{
					this.FindByName<Entry>("dri_calcium").Text = Application.Current.Properties["dri_calcium"] as String;
					this.FindByName<Entry>("dri_carbohydrates").Text = Application.Current.Properties["dri_carbohydrates"] as String;
					this.FindByName<Entry>("dri_protein").Text = Application.Current.Properties["dri_protein"] as String;
					this.FindByName<Entry>("dri_vitaminA").Text = Application.Current.Properties["dri_vitaminA"] as String;
					this.FindByName<Entry>("dri_vitaminC").Text = Application.Current.Properties["dri_vitaminC"] as String;
					this.FindByName<Entry>("dri_vitaminD").Text = Application.Current.Properties["dri_vitaminD"] as String;
					this.FindByName<Entry>("dri_vitaminE").Text = Application.Current.Properties["dri_vitaminE"] as String;
					this.FindByName<Entry>("dri_thiamin").Text = Application.Current.Properties["dri_thiamin"] as String;
					this.FindByName<Entry>("dri_riboflavin").Text = Application.Current.Properties["dri_riboflavin"] as String;
					this.FindByName<Entry>("dri_niacin").Text = Application.Current.Properties["dri_niacin"] as String;
					this.FindByName<Entry>("dri_vitaminB6").Text = Application.Current.Properties["dri_vitaminB6"] as String;
					this.FindByName<Entry>("dri_folate").Text = Application.Current.Properties["dri_folate"] as String;
					this.FindByName<Entry>("dri_vitaminB12").Text = Application.Current.Properties["dri_vitaminB12"] as String;
					this.FindByName<Entry>("dri_copper").Text = Application.Current.Properties["dri_copper"] as String;
					this.FindByName<Entry>("dri_iodine").Text = Application.Current.Properties["dri_iodine"] as String;
					this.FindByName<Entry>("dri_iron").Text = Application.Current.Properties["dri_iron"] as String;
					this.FindByName<Entry>("dri_magnesium").Text = Application.Current.Properties["dri_magnesium"] as String;
					this.FindByName<Entry>("dri_molybdenum").Text = Application.Current.Properties["dri_molybdenum"] as String;
					this.FindByName<Entry>("dri_phosphorus").Text = Application.Current.Properties["dri_phosphorus"] as String;
					this.FindByName<Entry>("dri_selenium").Text = Application.Current.Properties["dri_selenium"] as String;
					this.FindByName<Entry>("dri_zinc").Text = Application.Current.Properties["dri_zinc"] as String;
				}
				else {

				}

			}
			else {

			}


}
}
