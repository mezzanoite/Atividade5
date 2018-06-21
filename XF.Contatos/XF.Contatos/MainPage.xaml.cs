using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.Contatos
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void btnLigar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new API.PhoneView());
        }

        private async void btnLocation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GPS.CoordenadaView());
        }

        private async void btnContacts_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contatos.ContatosView());
        }
    }
}
