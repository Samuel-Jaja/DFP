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
    public partial class DfpPage4 : ContentPage
    {
        public DfpPage4()
        {
            InitializeComponent();
        }

        private void NextIterationButton_Clicked(object sender, EventArgs e)
        {

        }

        async private void Next2ndIterationButton_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new DfpPage5());
        }

       async private void BackButtonIterationTwoPage_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new DfpPage3());
        }
    }
}