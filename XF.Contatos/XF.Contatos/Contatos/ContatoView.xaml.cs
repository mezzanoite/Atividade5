using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using XF.Contatos.Camera;
using XF.Contatos.GPS;
using Plugin.ExternalMaps;
using System.Globalization;
using System.Net;

namespace XF.Contatos.Contatos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatoView : ContentPage
	{

		public ContatoView ()
		{
			InitializeComponent ();
            ILocalizacao geolocation = DependencyService.Get<ILocalizacao>();
            geolocation.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>
                (this, "coordenada", (objeto, geo) =>
                {
                    lblLongitude.Text = geo.Longitude;
                    lblLatitude.Text = geo.Latitude;
                });
        }

       private void TakeAPhotoButton_OnClicked(object sender, EventArgs e)
        {

            ICamera camera = DependencyService.Get<ICamera>();
            camera.TakePicture();
            MessagingCenter.Subscribe<ICamera, string>
                (this, "camera", (objeto, filePath) =>
                {
                    imageContato.Source = filePath;
                });
        }

        private async void VerNoMapa_OnClicked(object sender, EventArgs e)
        {
            double longitude = double.Parse(lblLongitude.Text, CultureInfo.InvariantCulture);
            double latitude = double.Parse(lblLatitude.Text, CultureInfo.InvariantCulture);
            Console.WriteLine(longitude);
            Console.WriteLine(latitude);
            //var success = await CrossExternalMaps.Current.NavigateTo("Space Needle", latitude, longitude);
            Device.OpenUri(new Uri(string.Format("geo:" + lblLatitude.Text + "," + lblLongitude.Text + "?q={0}", WebUtility.UrlEncode("Meu endereço"))));
        }
    }
}