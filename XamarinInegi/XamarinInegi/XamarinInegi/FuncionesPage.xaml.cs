using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinInegi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesPage : TabbedPage
    {
        string base64;
        private static HttpClient client = new HttpClient();

        public FuncionesPage (string emailParametro)
        {
            InitializeComponent();
            inegiImage.Source = ImageSource.FromFile("inegi.png");
            lblMensajeFromBD.Text = emailParametro;
            if (Application.Current.Properties.ContainsKey("session"))
            {
                persist.Text = Convert.ToString(Application.Current.Properties["session"]);
            }
        }

        public FuncionesPage()
        {
            InitializeComponent();
            inegiImage.Source = ImageSource.FromFile("inegi.png");
            if (Application.Current.Properties.ContainsKey("session"))
            {
                persist.Text = Convert.ToString(Application.Current.Properties["session"]);
            }
        }

        public async Task btnMensajeToBD_ClickedAsync(object sender, EventArgs e)
        {
            /*
                    var stream = photo.GetStream();
                    var bytes = new byte[stream.Length];
                    stream.ReadAsync(bytes, 0, (int)stream.Length);
                    base64 = System.Convert.ToBase64String(bytes);
                    lblMensajeFromBD.Text = base64;
             * 
             */
            bool isMensajeEmpty = string.IsNullOrEmpty(entMensajeToBD.Text);
            string Email = lblMensajeFromBD.Text;
            string Mensaje = entMensajeToBD.Text;
            var values = new Dictionary<string, string>
            {
                {"email", Email },
                {"mensaje", Mensaje },
                {"fotografia", base64 }
            };
            try
            {
                var content = new FormUrlEncodedContent(values);
                if (isMensajeEmpty)
                {
                    await DisplayAlert("Error", "Alguna de las credenciales falta", "Ok");
                }
                else
                {
                    var response = await client.PostAsync("http://192.168.1.70/laboratorio/products/", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Respuesta", responseString, "OK");
                }
            } catch (Exception ex)
            {
                await DisplayAlert("Excepción", ex.ToString(), "OK");
            }
            
            
        }

        private async void cameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                CustomPhotoSize = 5
            });
            if(photo != null)
            {
                photoImage.Source = ImageSource.FromStream(() => {

                    var stream = photo.GetStream();
                    
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    base64 = System.Convert.ToBase64String(bytes);
                    return photo.GetStream();
                });
                
            }
        }

        private async void cerrarSesion_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("session"))
            {
                Application.Current.Properties.Clear();
                await DisplayAlert("Sesion", "Cerrando sesion", "Ok");
                //var existingPages = Navigation.NavigationStack.ToList();
                Navigation.InsertPageBefore(new Login(), this);
                await Navigation.PopAsync();
            }
        }
    }
}