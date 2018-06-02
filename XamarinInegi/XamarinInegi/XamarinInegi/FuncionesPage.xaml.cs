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
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;

namespace XamarinInegi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [SerializableAttribute]
    public partial class FuncionesPage : TabbedPage
    {
        string base64;
        string base64Video;
        private static HttpClient client = new HttpClient();
        Plugin.Media.Abstractions.MediaFile video = null;

        public FuncionesPage()
        {
            InitializeComponent();
            inegiImage.Source = ImageSource.FromFile("inegi.png");
            photoImage.Source = ImageSource.FromUri(new Uri("http://192.168.0.5/laboratorio/products/uploads/73.png"));
            if (Application.Current.Properties.ContainsKey("session"))
            {
                persist.Text = Convert.ToString(Application.Current.Properties["session"]);
            }
        }

        public FuncionesPage(string emailParametro)
        {
            InitializeComponent();
            inegiImage.Source = ImageSource.FromFile("inegi.png");
            lblMensajeFromBD.Text = emailParametro;
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
                    var response = await client.PostAsync("http://192.168.0.5/laboratorio/products/", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Respuesta", responseString, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepción", ex.ToString(), "OK");
            }


        }

        private async void cameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                CustomPhotoSize = 5
            });
            if (photo != null)
            {
                photoImage.Source = ImageSource.FromStream(() =>
                {

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

        private async void PlayPauseButton_Clicked(object sender, EventArgs e)
        {
            if (video == null)
            {
                await DisplayAlert("Error", "Por favor primero toma un video dando clic en TOMAR VIDEO", "Ok");
            }
            else
            {
                if (PlayPauseButton.Text == "Stop")
                {
                    await CrossMediaManager.Current.Stop();
                    PlayPauseButton.Text = "Play";
                }
                else if (PlayPauseButton.Text == "Play")
                {
                    await CrossMediaManager.Current.Play(video.AlbumPath, MediaFileType.Video);
                    PlayPauseButton.Text = "Stop";
                }
            }
        }

        private async Task PickVideo_ClickedAsync(object sender, EventArgs e)
        {
            video = await Plugin.Media.CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions()
            {
                SaveToAlbum = true
            });
            await CrossMediaManager.Current.Play(video.AlbumPath, MediaFileType.Video);
            PlayPauseButton.Text = "Stop";
            PickVideo.IsEnabled = false;
        }

        private async void UploadVideo_Clicked(object sender, EventArgs e)
        {
            if (video == null)
            {
                await DisplayAlert("Error", "Por favor primero toma un video dando clic en TOMAR VIDEO", "Ok");
            }
            else
            {
                var stream = video.GetStream();
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                base64Video = System.Convert.ToBase64String(bytes);
                string Email = lblMensajeFromBD.Text;
                var values = new Dictionary<string, string>
            {
                {"email", Email },
                {"video", base64Video }
            };

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(video.GetStream()), "video", Email+".mp4");
                try
                {
                    //var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("http://192.168.0.5/laboratorio/videos/", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Respuesta", responseString, "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Excepción", ex.ToString(), "OK");
                }
            }

        }
    }
}
