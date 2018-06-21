using Android.App;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Geolocation;
using XF.Contatos.Droid;
using XF.Contatos.Contatos;
using System.Diagnostics;
using Xamarin.Contacts;
using System.Collections.Generic;
using System.Linq;

[assembly: Dependency(typeof(Contatos_Android))]
namespace XF.Contatos.Droid
{
    class Contatos_Android : IContato
    {
        public async void GetContatos()
        {
            var context = MainApplication.CurrentContext as Activity;
            var book = new AddressBook(context);

            if (!await book.RequestPermission())
            {
                Debug.WriteLine("Permission denied by user or manifest");
                return;
            }

            List<Contato> listaContato = new List<Contato>();
            foreach (Contact contact in book)
            {
                Contato contato = new Contato();
                contato.Nome = contact.DisplayName;
                contato.Numero = contact.Phones.First().Number;
                listaContato.Add(contato);
            }

            // Enviar coordenada via MessagingCenter
            MessagingCenter.Send<IContato, List<Contato>>(this, "contatos", listaContato);
        }
    }
}