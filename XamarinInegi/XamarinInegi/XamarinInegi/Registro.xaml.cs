using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinInegi
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
            imgRegistro.Source = ImageSource.FromFile("add_user.png");
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnLinkToLogin_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Login());
        }
    }
}