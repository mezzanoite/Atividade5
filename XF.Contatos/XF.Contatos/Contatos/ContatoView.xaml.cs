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

namespace XF.Contatos.Contatos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatoView : ContentPage
	{

        private string latitude;
        private string longitude;

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

        private void VerNoMapa_OnClicked(object sender, EventArgs e)
        {
            /*ILocalizacao geolocation = DependencyService.Get<ILocalizacao>();
            geolocation.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>
                (this, "coordenada", (objeto, geo) =>
                {
                    lblLongitude.Text = geo.Longitude;
                    lblLatitude.Text = geo.Latitude;
                });*/
        }
    }
}