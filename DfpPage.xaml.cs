using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PoastSuite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DfpPage : ContentPage
    {
        public DfpPage()
        {
            InitializeComponent();
        }

       async private void NextButtonSelectionQuestionPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DfpPage2());
            //if (Question1CheckBox.IsChecked)
            //{
               
            //}

        }

       async private void BackButtonSelectQuestionPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomePage());
        }


        //private void WelcomeStartTechniqueButton_Clicked(object sender, EventArgs e)
        //{
        //    if (DfpCheckbox.IsChecked)
        //    {
        //        Navigation.PushAsync(new DfpPage());
        //    }

        //}
    }
}