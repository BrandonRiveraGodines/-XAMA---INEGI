using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            this.BindingContext = this;
        }

        private void btnLinkToFunciones_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(entEmailLogin.Text);
            bool isPassEmpty = string.IsNullOrEmpty(entPasswordLogin.Text);
            string Email = entEmailLogin.Text.ToString();
            string Password = entPasswordLogin.Text.ToString();
            String URL_LOGIN = "http://192.168.0.4/laboratorio/Login.php";

            if (isEmailEmpty || isPassEmpty)
            {
                
            } else
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, URL_LOGIN);
                    
                    
                }

                ((NavigationPage)this.Parent).PushAsync(new Funciones());
            }
        }

        private void btnLinkToRegistrar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
    }
}
