using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoastSuite.Table;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PoastSuite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

       async private void RegisterSignInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

       async private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();
            var item = new RegUserTable()
            {
                Username = Entryusername.Text,
                Password = Entrypassword.Text,
                Email = Entryemail.Text,
                Matricno = Entrymatricno.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () => {
                var results = await this.DisplayAlert("Congratulations", "User Registration Successful", "Yes", "Cancel");
            });

            //This Code retrives Username and Mat Number and sends to Confirmation Page
            string confirmUsername = Entryusername.Text;
            string confirmMatno = Entrymatricno.Text;

            Entryusername.Text = confirmUsername;
            Entrymatricno.Text = confirmMatno;
            await Navigation.PushAsync(new UserConfirmationPage(Entryusername.Text, Entrymatricno.Text));


        }
    }
}