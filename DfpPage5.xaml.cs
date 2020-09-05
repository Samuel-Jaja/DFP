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
    public partial class DfpPage5 : ContentPage
    {
        public DfpPage5()
        {
            InitializeComponent();
        }

       async private void Next3rdIterationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DfpPage6());
        }

      async private void BackButtonIterationThreePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DfpPage4());
        }
    }
}