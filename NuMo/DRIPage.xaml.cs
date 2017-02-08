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

		public void setValues()
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
				this.FindByName<Label>("dri_calcium").Text = "";
				this.FindByName<Label>("dri_carbohydrates").Text = "";
				this.FindByName<Label>("dri_protein").Text = "1";
				this.FindByName<Label>("dri_vitaminA").Text = "";
				this.FindByName<Label>("dri_vitaminC").Text = "";
				this.FindByName<Label>("dri_vitaminD").Text = "";
				this.FindByName<Label>("dri_vitaminE").Text = "";
				this.FindByName<Label>("dri_thiamin").Text = "";
				this.FindByName<Label>("dri_riboflavin").Text = "";
				this.FindByName<Label>("dri_niacin").Text = "";
				this.FindByName<Label>("dri_vitaminB6").Text = "";
				this.FindByName<Label>("dri_folate").Text = "";
				this.FindByName<Label>("dri_vitaminB12").Text = "";
				this.FindByName<Label>("dri_copper").Text = "";
				this.FindByName<Label>("dri_iodine").Text = "";
				this.FindByName<Label>("dri_iron").Text = "6.9";
				this.FindByName<Label>("dri_magnesium").Text = "";
				this.FindByName<Label>("dri_molybdenum").Text = "";
				this.FindByName<Label>("dri_phosphorus").Text = "";
				this.FindByName<Label>("dri_selenium").Text = "";
				this.FindByName<Label>("dri_zinc").Text = "2.5";
			}

			//Calculations for Children
			else if (ageNum >= 1 && ageNum <= 3)
			{
				this.FindByName<Label>("dri_calcium").Text = "500";
				this.FindByName<Label>("dri_carbohydrates").Text = "100";
				this.FindByName<Label>("dri_protein").Text = ".87";
				this.FindByName<Label>("dri_vitaminA").Text = "210";
				this.FindByName<Label>("dri_vitaminC").Text = "13";
				this.FindByName<Label>("dri_vitaminD").Text = "10";
				this.FindByName<Label>("dri_vitaminE").Text = "5";
				this.FindByName<Label>("dri_thiamin").Text = ".4";
				this.FindByName<Label>("dri_riboflavin").Text = ".4";
				this.FindByName<Label>("dri_niacin").Text = "5";
				this.FindByName<Label>("dri_vitaminB6").Text = ".4";
				this.FindByName<Label>("dri_folate").Text = "120";
				this.FindByName<Label>("dri_vitaminB12").Text = ".7";
				this.FindByName<Label>("dri_copper").Text = "260";
				this.FindByName<Label>("dri_iodine").Text = "65";
				this.FindByName<Label>("dri_iron").Text = "3";
				this.FindByName<Label>("dri_magnesium").Text = "65";
				this.FindByName<Label>("dri_molybdenum").Text = "13";
				this.FindByName<Label>("dri_phosphorus").Text = "380";
				this.FindByName<Label>("dri_selenium").Text = "17";
				this.FindByName<Label>("dri_zinc").Text = "2.5";
			}
			//calculations for older children
			else if (ageNum >= 4 && ageNum <= 8)
			{
				this.FindByName<Label>("dri_calcium").Text = "800";
				this.FindByName<Label>("dri_carbohydrates").Text = "100";
				this.FindByName<Label>("dri_protein").Text = ".76";
				this.FindByName<Label>("dri_vitaminA").Text = "275";
				this.FindByName<Label>("dri_vitaminC").Text = "22";
				this.FindByName<Label>("dri_vitaminD").Text = "10";
				this.FindByName<Label>("dri_vitaminE").Text = "6";
				this.FindByName<Label>("dri_thiamin").Text = ".5";
				this.FindByName<Label>("dri_riboflavin").Text = ".5";
				this.FindByName<Label>("dri_niacin").Text = "6";
				this.FindByName<Label>("dri_vitaminB6").Text = ".5";
				this.FindByName<Label>("dri_folate").Text = "160";
				this.FindByName<Label>("dri_vitaminB12").Text = "1";
				this.FindByName<Label>("dri_copper").Text = "340";
				this.FindByName<Label>("dri_iodine").Text = "65";
				this.FindByName<Label>("dri_iron").Text = "4.1";
				this.FindByName<Label>("dri_magnesium").Text = "110";
				this.FindByName<Label>("dri_molybdenum").Text = "17";
				this.FindByName<Label>("dri_phosphorus").Text = "405";
				this.FindByName<Label>("dri_selenium").Text = "23";
				this.FindByName<Label>("dri_zinc").Text = "4";

			}
			//calculations for adults
			else {
				//Males
				if (gender == 1)
				{
					//9-13
					if (ageNum >= 9 && ageNum <= 13)
					{
						this.FindByName<Label>("dri_calcium").Text = "1100";
						this.FindByName<Label>("dri_carbohydrates").Text = "100";
						this.FindByName<Label>("dri_protein").Text = ".76";
						this.FindByName<Label>("dri_vitaminA").Text = "445";
						this.FindByName<Label>("dri_vitaminC").Text = "39";
						this.FindByName<Label>("dri_vitaminD").Text = "10";
						this.FindByName<Label>("dri_vitaminE").Text = "9";
						this.FindByName<Label>("dri_thiamin").Text = ".7";
						this.FindByName<Label>("dri_riboflavin").Text = ".8";
						this.FindByName<Label>("dri_niacin").Text = "9";
						this.FindByName<Label>("dri_vitaminB6").Text = ".8";
						this.FindByName<Label>("dri_folate").Text = "250";
						this.FindByName<Label>("dri_vitaminB12").Text = "1.5";
						this.FindByName<Label>("dri_copper").Text = "540";
						this.FindByName<Label>("dri_iodine").Text = "73";
						this.FindByName<Label>("dri_iron").Text = "5.9";
						this.FindByName<Label>("dri_magnesium").Text = "200";
						this.FindByName<Label>("dri_molybdenum").Text = "26";
						this.FindByName<Label>("dri_phosphorus").Text = "1,055";
						this.FindByName<Label>("dri_selenium").Text = "35";
						this.FindByName<Label>("dri_zinc").Text = "7";
					}
					//14-18
					else if (ageNum >= 14 && ageNum <= 18)
					{
						this.FindByName<Label>("dri_calcium").Text = "1100";
						this.FindByName<Label>("dri_carbohydrates").Text = "100";
						this.FindByName<Label>("dri_protein").Text = ".73";
						this.FindByName<Label>("dri_vitaminA").Text = "630";
						this.FindByName<Label>("dri_vitaminC").Text = "63";
						this.FindByName<Label>("dri_vitaminD").Text = "10";
						this.FindByName<Label>("dri_vitaminE").Text = "12";
						this.FindByName<Label>("dri_thiamin").Text = "1";
						this.FindByName<Label>("dri_riboflavin").Text = "1.1";
						this.FindByName<Label>("dri_niacin").Text = "12";
						this.FindByName<Label>("dri_vitaminB6").Text = "1.1";
						this.FindByName<Label>("dri_folate").Text = "330";
						this.FindByName<Label>("dri_vitaminB12").Text = "2";
						this.FindByName<Label>("dri_copper").Text = "685";
						this.FindByName<Label>("dri_iodine").Text = "95";
						this.FindByName<Label>("dri_iron").Text = "7.7";
						this.FindByName<Label>("dri_magnesium").Text = "340";
						this.FindByName<Label>("dri_molybdenum").Text = "33";
						this.FindByName<Label>("dri_phosphorus").Text = "1055";
						this.FindByName<Label>("dri_selenium").Text = "45";
						this.FindByName<Label>("dri_zinc").Text = "8.5";
					}
					//19-30
					else if (ageNum >= 19 && ageNum <= 30)
					{
						this.FindByName<Label>("dri_calcium").Text = "800";
						this.FindByName<Label>("dri_carbohydrates").Text = "100";
						this.FindByName<Label>("dri_protein").Text = ".66";
						this.FindByName<Label>("dri_vitaminA").Text = "625";
						this.FindByName<Label>("dri_vitaminC").Text = "75";
						this.FindByName<Label>("dri_vitaminD").Text = "10";
						this.FindByName<Label>("dri_vitaminE").Text = "12";
						this.FindByName<Label>("dri_thiamin").Text = "1";
						this.FindByName<Label>("dri_riboflavin").Text = "1.1";
						this.FindByName<Label>("dri_niacin").Text = "12";
						this.FindByName<Label>("dri_vitaminB6").Text = "1.1";
						this.FindByName<Label>("dri_folate").Text = "320";
						this.FindByName<Label>("dri_vitaminB12").Text = "2";
						this.FindByName<Label>("dri_copper").Text = "700";
						this.FindByName<Label>("dri_iodine").Text = "95";
						this.FindByName<Label>("dri_iron").Text = "6";
						this.FindByName<Label>("dri_magnesium").Text = "330";
						this.FindByName<Label>("dri_molybdenum").Text = "34";
						this.FindByName<Label>("dri_phosphorus").Text = "580";
						this.FindByName<Label>("dri_selenium").Text = "45";
						this.FindByName<Label>("dri_zinc").Text = "9.4";
					}
					//31-50
					else if (ageNum >= 31 && ageNum <= 50)
					{
						this.FindByName<Label>("dri_calcium").Text = "800";
						this.FindByName<Label>("dri_carbohydrates").Text = "100";
						this.FindByName<Label>("dri_protein").Text = ".66";
						this.FindByName<Label>("dri_vitaminA").Text = "625";
						this.FindByName<Label>("dri_vitaminC").Text = "75";
						this.FindByName<Label>("dri_vitaminD").Text = "10";
						this.FindByName<Label>("dri_vitaminE").Text = "12";
						this.FindByName<Label>("dri_thiamin").Text = "1";
						this.FindByName<Label>("dri_riboflavin").Text = "1.1";
						this.FindByName<Label>("dri_niacin").Text = "12";
						this.FindByName<Label>("dri_vitaminB6").Text = "1.1";
						this.FindByName<Label>("dri_folate").Text = "320";
						this.FindByName<Label>("dri_vitaminB12").Text = "2";
						this.FindByName<Label>("dri_copper").Text = "700";
						this.FindByName<Label>("dri_iodine").Text = "95";
						this.FindByName<Label>("dri_iron").Text = "6";
						this.FindByName<Label>("dri_magnesium").Text = "350";
						this.FindByName<Label>("dri_molybdenum").Text = "34";
						this.FindByName<Label>("dri_phosphorus").Text = "580";
						this.FindByName<Label>("dri_selenium").Text = "45";
						this.FindByName<Label>("dri_zinc").Text = "9.4";
					}
					//51-70
					else if (ageNum >= 51 && ageNum <= 70)
					{
						this.FindByName<Label>("dri_calcium").Text = "800";
						this.FindByName<Label>("dri_carbohydrates").Text = "100";
						this.FindByName<Label>("dri_protein").Text = ".66";
						this.FindByName<Label>("dri_vitaminA").Text = "625";
						this.FindByName<Label>("dri_vitaminC").Text = "75";
						this.FindByName<Label>("dri_vitaminD").Text = "10";
						this.FindByName<Label>("dri_vitaminE").Text = "12";
						this.FindByName<Label>("dri_thiamin").Text = "1";
						this.FindByName<Label>("dri_riboflavin").Text = "1.1";
						this.FindByName<Label>("dri_niacin").Text = "12";
						this.FindByName<Label>("dri_vitaminB6").Text = "1.4";
						this.FindByName<Label>("dri_folate").Text = "320";
						this.FindByName<Label>("dri_vitaminB12").Text = "2";
						this.FindByName<Label>("dri_copper").Text = "700";
						this.FindByName<Label>("dri_iodine").Text = "95";
						this.FindByName<Label>("dri_iron").Text = "6";
						this.FindByName<Label>("dri_magnesium").Text = "350";
						this.FindByName<Label>("dri_molybdenum").Text = "34";
						this.FindByName<Label>("dri_phosphorus").Text = "580";
						this.FindByName<Label>("dri_selenium").Text = "45";
						this.FindByName<Label>("dri_zinc").Text = "9.4";
					}
					//70+
					else if (ageNum > 70)
					{
						this.FindByName<Label>("dri_calcium").Text = "1000";
						this.FindByName<Label>("dri_carbohydrates").Text = "100";
						this.FindByName<Label>("dri_protein").Text = ".66";
						this.FindByName<Label>("dri_vitaminA").Text = "625";
						this.FindByName<Label>("dri_vitaminC").Text = "75";
						this.FindByName<Label>("dri_vitaminD").Text = "10";
						this.FindByName<Label>("dri_vitaminE").Text = "12";
						this.FindByName<Label>("dri_thiamin").Text = "1";
						this.FindByName<Label>("dri_riboflavin").Text = "1.1";
						this.FindByName<Label>("dri_niacin").Text = "12";
						this.FindByName<Label>("dri_vitaminB6").Text = "1.4";
						this.FindByName<Label>("dri_folate").Text = "320";
						this.FindByName<Label>("dri_vitaminB12").Text = "2";
						this.FindByName<Label>("dri_copper").Text = "700";
						this.FindByName<Label>("dri_iodine").Text = "95";
						this.FindByName<Label>("dri_iron").Text = "6";
						this.FindByName<Label>("dri_magnesium").Text = "350";
						this.FindByName<Label>("dri_molybdenum").Text = "34";
						this.FindByName<Label>("dri_phosphorus").Text = "580";
						this.FindByName<Label>("dri_selenium").Text = "45";
						this.FindByName<Label>("dri_zinc").Text = "9.4";
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
							this.FindByName<Label>("dri_calcium").Text = "1100";
							this.FindByName<Label>("dri_carbohydrates").Text = "100";
							this.FindByName<Label>("dri_protein").Text = ".76";
							this.FindByName<Label>("dri_vitaminA").Text = "420";
							this.FindByName<Label>("dri_vitaminC").Text = "39";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "9";
							this.FindByName<Label>("dri_thiamin").Text = ".7";
							this.FindByName<Label>("dri_riboflavin").Text = ".8";
							this.FindByName<Label>("dri_niacin").Text = "9";
							this.FindByName<Label>("dri_vitaminB6").Text = ".8";
							this.FindByName<Label>("dri_folate").Text = "250";
							this.FindByName<Label>("dri_vitaminB12").Text = "1.5";
							this.FindByName<Label>("dri_copper").Text = "540";
							this.FindByName<Label>("dri_iodine").Text = "73";
							this.FindByName<Label>("dri_iron").Text = "5.7";
							this.FindByName<Label>("dri_magnesium").Text = "200";
							this.FindByName<Label>("dri_molybdenum").Text = "26";
							this.FindByName<Label>("dri_phosphorus").Text = "1,055";
							this.FindByName<Label>("dri_selenium").Text = "35";
							this.FindByName<Label>("dri_zinc").Text = "7";
						}
						//14-18
						else if (ageNum >= 14 && ageNum <= 18)
						{
							this.FindByName<Label>("dri_calcium").Text = "1100";
							this.FindByName<Label>("dri_carbohydrates").Text = "100";
							this.FindByName<Label>("dri_protein").Text = ".71";
							this.FindByName<Label>("dri_vitaminA").Text = "485";
							this.FindByName<Label>("dri_vitaminC").Text = "56";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = ".9";
							this.FindByName<Label>("dri_riboflavin").Text = ".9";
							this.FindByName<Label>("dri_niacin").Text = "11";
							this.FindByName<Label>("dri_vitaminB6").Text = "1";
							this.FindByName<Label>("dri_folate").Text = "330";
							this.FindByName<Label>("dri_vitaminB12").Text = "2";
							this.FindByName<Label>("dri_copper").Text = "685";
							this.FindByName<Label>("dri_iodine").Text = "95";
							this.FindByName<Label>("dri_iron").Text = "7.9";
							this.FindByName<Label>("dri_magnesium").Text = "300";
							this.FindByName<Label>("dri_molybdenum").Text = "33";
							this.FindByName<Label>("dri_phosphorus").Text = "1055";
							this.FindByName<Label>("dri_selenium").Text = "45";
							this.FindByName<Label>("dri_zinc").Text = "7.3";
						}
						//19-30
						else if (ageNum >= 19 && ageNum <= 30)
						{
							this.FindByName<Label>("dri_calcium").Text = "800";
							this.FindByName<Label>("dri_carbohydrates").Text = "100";
							this.FindByName<Label>("dri_protein").Text = ".66";
							this.FindByName<Label>("dri_vitaminA").Text = "500";
							this.FindByName<Label>("dri_vitaminC").Text = "60";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = ".9";
							this.FindByName<Label>("dri_riboflavin").Text = ".9";
							this.FindByName<Label>("dri_niacin").Text = "11";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.1";
							this.FindByName<Label>("dri_folate").Text = "320";
							this.FindByName<Label>("dri_vitaminB12").Text = "2";
							this.FindByName<Label>("dri_copper").Text = "700";
							this.FindByName<Label>("dri_iodine").Text = "95";
							this.FindByName<Label>("dri_iron").Text = "8.1";
							this.FindByName<Label>("dri_magnesium").Text = "255";
							this.FindByName<Label>("dri_molybdenum").Text = "34";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "45";
							this.FindByName<Label>("dri_zinc").Text = "6.8";
						}

						//31-50
						else if (ageNum >= 31 && ageNum <= 50)
						{
							this.FindByName<Label>("dri_calcium").Text = "800";
							this.FindByName<Label>("dri_carbohydrates").Text = "100";
							this.FindByName<Label>("dri_protein").Text = ".66";
							this.FindByName<Label>("dri_vitaminA").Text = "500";
							this.FindByName<Label>("dri_vitaminC").Text = "60";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = ".9";
							this.FindByName<Label>("dri_riboflavin").Text = ".9";
							this.FindByName<Label>("dri_niacin").Text = "11";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.1";
							this.FindByName<Label>("dri_folate").Text = "320";
							this.FindByName<Label>("dri_vitaminB12").Text = "2";
							this.FindByName<Label>("dri_copper").Text = "700";
							this.FindByName<Label>("dri_iodine").Text = "95";
							this.FindByName<Label>("dri_iron").Text = "8.1";
							this.FindByName<Label>("dri_magnesium").Text = "265";
							this.FindByName<Label>("dri_molybdenum").Text = "34";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "45";
							this.FindByName<Label>("dri_zinc").Text = "6.8";
						}
						//51-70
						else if (ageNum >= 51 && ageNum <= 70)
						{
							this.FindByName<Label>("dri_calcium").Text = "1000";
							this.FindByName<Label>("dri_carbohydrates").Text = "100";
							this.FindByName<Label>("dri_protein").Text = ".66";
							this.FindByName<Label>("dri_vitaminA").Text = "500";
							this.FindByName<Label>("dri_vitaminC").Text = "60";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = ".9";
							this.FindByName<Label>("dri_riboflavin").Text = ".9";
							this.FindByName<Label>("dri_niacin").Text = "11";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.3";
							this.FindByName<Label>("dri_folate").Text = "320";
							this.FindByName<Label>("dri_vitaminB12").Text = "2";
							this.FindByName<Label>("dri_copper").Text = "700";
							this.FindByName<Label>("dri_iodine").Text = "95";
							this.FindByName<Label>("dri_iron").Text = "5";
							this.FindByName<Label>("dri_magnesium").Text = "265";
							this.FindByName<Label>("dri_molybdenum").Text = "34";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "45";
							this.FindByName<Label>("dri_zinc").Text = "6.8";
						}
						//70+
						else if (ageNum > 70)
						{
							this.FindByName<Label>("dri_calcium").Text = "1000";
							this.FindByName<Label>("dri_carbohydrates").Text = "100";
							this.FindByName<Label>("dri_protein").Text = ".66";
							this.FindByName<Label>("dri_vitaminA").Text = "500";
							this.FindByName<Label>("dri_vitaminC").Text = "60";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = ".9";
							this.FindByName<Label>("dri_riboflavin").Text = ".9";
							this.FindByName<Label>("dri_niacin").Text = "11";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.3";
							this.FindByName<Label>("dri_folate").Text = "320";
							this.FindByName<Label>("dri_vitaminB12").Text = "2";
							this.FindByName<Label>("dri_copper").Text = "700";
							this.FindByName<Label>("dri_iodine").Text = "95";
							this.FindByName<Label>("dri_iron").Text = "5";
							this.FindByName<Label>("dri_magnesium").Text = "265";
							this.FindByName<Label>("dri_molybdenum").Text = "34";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "45";
							this.FindByName<Label>("dri_zinc").Text = "6.8";
						}
					}
					//pregnant women
					else if (pregnant == 1 && lactating == 0)
					{
						//14-18
						if (ageNum >= 14 && ageNum <= 18)
						{
							this.FindByName<Label>("dri_calcium").Text = "1000";
							this.FindByName<Label>("dri_carbohydrates").Text = "135";
							this.FindByName<Label>("dri_protein").Text = ".88";
							this.FindByName<Label>("dri_vitaminA").Text = "530";
							this.FindByName<Label>("dri_vitaminC").Text = "66";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = "1.2";
							this.FindByName<Label>("dri_riboflavin").Text = "1.2";
							this.FindByName<Label>("dri_niacin").Text = "14";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.6";
							this.FindByName<Label>("dri_folate").Text = "520";
							this.FindByName<Label>("dri_vitaminB12").Text = "2.2";
							this.FindByName<Label>("dri_copper").Text = "785";
							this.FindByName<Label>("dri_iodine").Text = "160";
							this.FindByName<Label>("dri_iron").Text = "23";
							this.FindByName<Label>("dri_magnesium").Text = "335";
							this.FindByName<Label>("dri_molybdenum").Text = "40";
							this.FindByName<Label>("dri_phosphorus").Text = "1055";
							this.FindByName<Label>("dri_selenium").Text = "49";
							this.FindByName<Label>("dri_zinc").Text = "10.5";
						}
						//19-30
						else if (ageNum >= 19 && ageNum <= 30)
						{
							this.FindByName<Label>("dri_calcium").Text = "800";
							this.FindByName<Label>("dri_carbohydrates").Text = "135";
							this.FindByName<Label>("dri_protein").Text = ".88";
							this.FindByName<Label>("dri_vitaminA").Text = "550";
							this.FindByName<Label>("dri_vitaminC").Text = "70";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = "1.2";
							this.FindByName<Label>("dri_riboflavin").Text = "1.2";
							this.FindByName<Label>("dri_niacin").Text = "14";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.6";
							this.FindByName<Label>("dri_folate").Text = "520";
							this.FindByName<Label>("dri_vitaminB12").Text = "2.2";
							this.FindByName<Label>("dri_copper").Text = "800";
							this.FindByName<Label>("dri_iodine").Text = "160";
							this.FindByName<Label>("dri_iron").Text = "22";
							this.FindByName<Label>("dri_magnesium").Text = "290";
							this.FindByName<Label>("dri_molybdenum").Text = "40";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "49";
							this.FindByName<Label>("dri_zinc").Text = "9.5";
						}
						//31-50
						else if (ageNum >= 31 && ageNum <= 50)
						{
							this.FindByName<Label>("dri_calcium").Text = "800";
							this.FindByName<Label>("dri_carbohydrates").Text = "135";
							this.FindByName<Label>("dri_protein").Text = ".88";
							this.FindByName<Label>("dri_vitaminA").Text = "550";
							this.FindByName<Label>("dri_vitaminC").Text = "70";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "12";
							this.FindByName<Label>("dri_thiamin").Text = "1.2";
							this.FindByName<Label>("dri_riboflavin").Text = "1.2";
							this.FindByName<Label>("dri_niacin").Text = "14";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.6";
							this.FindByName<Label>("dri_folate").Text = "520";
							this.FindByName<Label>("dri_vitaminB12").Text = "2.2";
							this.FindByName<Label>("dri_copper").Text = "800";
							this.FindByName<Label>("dri_iodine").Text = "160";
							this.FindByName<Label>("dri_iron").Text = "22";
							this.FindByName<Label>("dri_magnesium").Text = "300";
							this.FindByName<Label>("dri_molybdenum").Text = "40";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "49";
							this.FindByName<Label>("dri_zinc").Text = "9.5";
						}
					}
					//lactating women
					else if (pregnant == 0 && lactating == 1)
					{
						//14-18
						if (ageNum >= 14 && ageNum <= 18)
						{
							this.FindByName<Label>("dri_calcium").Text = "1000";
							this.FindByName<Label>("dri_carbohydrates").Text = "160";
							this.FindByName<Label>("dri_protein").Text = "1.05";
							this.FindByName<Label>("dri_vitaminA").Text = "885";
							this.FindByName<Label>("dri_vitaminC").Text = "96";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "16";
							this.FindByName<Label>("dri_thiamin").Text = "1.2";
							this.FindByName<Label>("dri_riboflavin").Text = "1.3";
							this.FindByName<Label>("dri_niacin").Text = "13";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.7";
							this.FindByName<Label>("dri_folate").Text = "450";
							this.FindByName<Label>("dri_vitaminB12").Text = "2.4";
							this.FindByName<Label>("dri_copper").Text = "985";
							this.FindByName<Label>("dri_iodine").Text = "209";
							this.FindByName<Label>("dri_iron").Text = "7";
							this.FindByName<Label>("dri_magnesium").Text = "300";
							this.FindByName<Label>("dri_molybdenum").Text = "35";
							this.FindByName<Label>("dri_phosphorus").Text = "1055";
							this.FindByName<Label>("dri_selenium").Text = "59";
							this.FindByName<Label>("dri_zinc").Text = "10.9";
						}
						//19-30
						else if (ageNum >= 19 && ageNum <= 30)
						{
							this.FindByName<Label>("dri_calcium").Text = "800";
							this.FindByName<Label>("dri_carbohydrates").Text = "160";
							this.FindByName<Label>("dri_protein").Text = "1.05";
							this.FindByName<Label>("dri_vitaminA").Text = "900";
							this.FindByName<Label>("dri_vitaminC").Text = "100";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "16";
							this.FindByName<Label>("dri_thiamin").Text = "1.2";
							this.FindByName<Label>("dri_riboflavin").Text = "1.3";
							this.FindByName<Label>("dri_niacin").Text = "13";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.7";
							this.FindByName<Label>("dri_folate").Text = "450";
							this.FindByName<Label>("dri_vitaminB12").Text = "2.4";
							this.FindByName<Label>("dri_copper").Text = "1000";
							this.FindByName<Label>("dri_iodine").Text = "209";
							this.FindByName<Label>("dri_iron").Text = "6.5";
							this.FindByName<Label>("dri_magnesium").Text = "255";
							this.FindByName<Label>("dri_molybdenum").Text = "36";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "59";
							this.FindByName<Label>("dri_zinc").Text = "10.4";
						}
						//31-50
						else if (ageNum >= 31 && ageNum <= 50)
						{
							this.FindByName<Label>("dri_calcium").Text = "800";
							this.FindByName<Label>("dri_carbohydrates").Text = "160";
							this.FindByName<Label>("dri_protein").Text = "1.05";
							this.FindByName<Label>("dri_vitaminA").Text = "900";
							this.FindByName<Label>("dri_vitaminC").Text = "100";
							this.FindByName<Label>("dri_vitaminD").Text = "10";
							this.FindByName<Label>("dri_vitaminE").Text = "16";
							this.FindByName<Label>("dri_thiamin").Text = "1.2";
							this.FindByName<Label>("dri_riboflavin").Text = "1.3";
							this.FindByName<Label>("dri_niacin").Text = "13";
							this.FindByName<Label>("dri_vitaminB6").Text = "1.7";
							this.FindByName<Label>("dri_folate").Text = "450";
							this.FindByName<Label>("dri_vitaminB12").Text = "2.4";
							this.FindByName<Label>("dri_copper").Text = "1000";
							this.FindByName<Label>("dri_iodine").Text = "209";
							this.FindByName<Label>("dri_iron").Text = "6.5";
							this.FindByName<Label>("dri_magnesium").Text = "265";
							this.FindByName<Label>("dri_molybdenum").Text = "36";
							this.FindByName<Label>("dri_phosphorus").Text = "580";
							this.FindByName<Label>("dri_selenium").Text = "59";
							this.FindByName<Label>("dri_zinc").Text = "10.4";
						}
					}

				}

		}
	}
}
}
