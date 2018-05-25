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
	public partial class StartLoad : ContentPage
	{
		public StartLoad ()
		{
			InitializeComponent ();
            Inicio();
        }
        private async void Inicio()
        {
            await Task.Delay(1000);
            await DisplayAlert("JSON", Convert.ToString(Application.Current.Properties["session"]), "Ok");
            if (Application.Current.Properties.ContainsKey("session"))
            {
                Navigation.InsertPageBefore(new FuncionesPage(Convert.ToString(Application.Current.Properties["session"])), this);
                await Navigation.PopAsync();
            }
            else
            {
                Navigation.InsertPageBefore(new Login(), this);
                await Navigation.PopAsync();
            }
        }
        
	}
}