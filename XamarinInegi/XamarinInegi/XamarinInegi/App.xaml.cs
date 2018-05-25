using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamarinInegi
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            if (Application.Current.Properties.ContainsKey("session"))
            {
                MainPage = new NavigationPage(new FuncionesPage(Convert.ToString(Application.Current.Properties["session"])));
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
            //MainPage = new NavigationPage(new StartLoad());
            
        }

		protected override void OnStart ()
		{
            
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

    }
}
