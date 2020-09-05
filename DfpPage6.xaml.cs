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
    public partial class DfpPage6 : ContentPage
    {
        public DfpPage6()
        {
            InitializeComponent();
        }

        private void ReviewAndGrade_Clicked(object sender, EventArgs e)
        {

        }

       async private void BackButtonIterationFourPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DfpPage5());
        }
    }
}