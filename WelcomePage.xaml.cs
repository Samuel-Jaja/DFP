using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoastSuite.Table;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PoastSuite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage(string username)
        {
            //This code enables to remove navigation bar property 
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            LabelHelloFriend.Text = username;
        }

        public WelcomePage()
        {
        }

        async private void WelcomeLogoutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void WelcomeStartTechniqueButton_Clicked(object sender, EventArgs e)
        {
            if (DfpCheckbox.IsChecked)
            {
                Navigation.PushAsync(new DfpPage());
            }

        }

        private void Dfpcheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //if (e.Value==true)
            //{
            //    lblCheckeddpf.Text = "Great Choice for selecting a Gradient Method:DFP Technique";
            //}
            //else
            //{
            //    lblCheckeddpf.Text = "DFP Method is a Great Choice to Start";
            //}

        }
    }
}