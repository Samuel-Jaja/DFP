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
    public partial class UserConfirmationPage : ContentPage
    {

        public UserConfirmationPage( string parameterusername, string parametermatno)
        {
            InitializeComponent();
            EntryConfirmUsername.Text = parameterusername;
            EntryConfirmNatnumber.Text = parametermatno;
        }

       async private void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}