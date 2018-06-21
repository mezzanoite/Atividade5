using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.Contatos;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XF.Contatos
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new ContatosView());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
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
