using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.API;

namespace XF.Contatos.Contatos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatosView : ContentPage
	{
        public List<Contato> listaContatos { get; set; }

		public ContatosView ()
		{
			InitializeComponent ();

            IContato contatos = DependencyService.Get<IContato>();
            contatos.GetContatos();

            MessagingCenter.Subscribe<IContato, List<Contato>>
                (this, "contatos", (objeto, listaContatos) =>
                {
                    this.listaContatos = listaContatos;
                    lvContatos.ItemsSource = listaContatos;
                    
                    /*Console.WriteLine(listaContatos.Count);
                    foreach (Contato contato in listaContatos)
                    {
                        Console.WriteLine("##### " + contato.Nome + " " + contato.Numero + "\n");
                        Console.WriteLine("%%%%%%\n");
                    }*/
                });

        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Contato contato = e.Item as Contato;
            await Navigation.PushAsync(new ContatoView() { BindingContext = contato });
        }

        private void OnLigarClicked(object sender, EventArgs e)
        {
            var contatoCell = (Contato) ((Button)sender).BindingContext;
            var phone = DependencyService.Get<ILigar>();
            if (phone != null) phone.Discar(contatoCell.Numero);
        }
    }
}