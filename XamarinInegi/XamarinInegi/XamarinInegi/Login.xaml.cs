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
		}
    }
}
