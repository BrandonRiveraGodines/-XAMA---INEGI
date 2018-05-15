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
	public partial class Funciones : ContentPage
	{
		public Funciones ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}