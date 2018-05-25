using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinInegi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public static HttpClient client = new HttpClient();
        public Registro()
        {
            InitializeComponent();
            imgRegistro.Source = ImageSource.FromFile("add_user.png");
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnLinkToLogin_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Login());
        }

        private async Task btnRegistrarUsuario_ClickedAsync(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(entEmailRegistro.Text);
            bool isPassEmpty = string.IsNullOrEmpty(entPasswordRegistro.Text);
            bool isUserEmpty = string.IsNullOrEmpty(entUserNamePassword.Text);
            string Email = entEmailRegistro.Text;
            string Password = entPasswordRegistro.Text;
            string Name = entUserNamePassword.Text;
            var values = new Dictionary<string, string>
            {
                {"email", Email },
                {"password", Password },
                {"name", Name }
            };
            var content = new FormUrlEncodedContent(values);
            if (isEmailEmpty || isPassEmpty || isUserEmpty)
            {
                await DisplayAlert("Error", "Alguna de las credenciales falta", "Ok");
            }
            else
            {
                var response = await client.PostAsync("http://192.168.1.70/laboratorio/register/", content);
                var responseString = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(json: responseString);
                JObject user = jsonResponse.SelectToken("user").Value<JObject>();
                bool flag = jsonResponse.SelectToken("error").Value<bool>();
                await DisplayAlert("JSON", user.ToString(), "Ok");
                if (flag == false)
                {
                    await DisplayAlert("Éxito", "Usuario registrado con éxito", "Ok");
                    await ((NavigationPage)this.Parent).PushAsync(new Login());
                } else
                {
                    await DisplayAlert("Éxito", "El correo utilizado ya existe", "Ok");
                }
            }
        }
    }
}