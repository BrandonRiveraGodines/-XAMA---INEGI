using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinInegi
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
            userLoginImage.Source = ImageSource.FromFile("user.png");
            //((NavigationPage.SetHasBackButton()))
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnLinkToFunciones_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(entEmailLogin.Text);
            bool isPassEmpty = string.IsNullOrEmpty(entPasswordLogin.Text);

            if (isEmailEmpty || isPassEmpty)
            {
                
            } else
            {
                ((NavigationPage)this.Parent).PushAsync(new Funciones());
            }
        }

        private void btnLinkToRegistrar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
    }
}
