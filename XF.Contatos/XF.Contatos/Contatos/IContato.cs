using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Contatos.Contatos
{
    public interface IContato
    {
        void GetContatos();
    }

    public class Contato
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
    }
}
