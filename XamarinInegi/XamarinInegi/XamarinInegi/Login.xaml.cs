using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RestSharp;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XamarinInegi
{
    public partial class Login : ContentPage
    {
        private static HttpClient client = new HttpClient();

        public Login()
        {
            InitializeComponent();
            userLoginImage.Source = ImageSource.FromFile("user.png");
            //((NavigationPage.SetHasBackButton()))
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = this;
        }
    private async Task btnLinkToFunciones_ClickedAsync(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(entEmailLogin.Text);
            bool isPassEmpty = string.IsNullOrEmpty(entPasswordLogin.Text);
            string Email = entEmailLogin.Text;
            string Password = entPasswordLogin.Text;
            var values = new Dictionary<string, string>
            {
                {"email", Email },
                {"password", Password }
            };
            var content = new FormUrlEncodedContent(values);
            if (isEmailEmpty || isPassEmpty)
            {
                await DisplayAlert("Error", "Alguna de las credenciales falta", "Ok");
            }
            else
            {
                var response = await client.PostAsync("http://192.168.0.5/laboratorio/login/", content);
                var responseString = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(json: responseString);
                JObject user = jsonResponse.SelectToken("user").Value<JObject>();
                bool flag = jsonResponse.SelectToken("error").Value<bool>();
                await DisplayAlert("JSON", user.ToString(), "Ok");
                if (flag == false)
                {
                    Application.Current.Properties[ "session" ] = user.GetValue("email").ToString();
                    //await Navigation.PushAsync(new FuncionesPage(user.GetValue("email").ToString()));
                    Navigation.InsertPageBefore(new FuncionesPage(user.GetValue("email").ToString()), this);
                    await Navigation.PopAsync();
                    var pageEmailEnvio = new Funciones();
                } else
                {
                    await DisplayAlert("Error", "Error en las credenciales, favor de verificar.", "Ok");
                }
            }
        }

        private void btnLinkToRegistrar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
    }
}
