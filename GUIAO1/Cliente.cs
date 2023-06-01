using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class Cliente
    {
        private String _clienteID;
        private String _clienteNome;
        private String _clienteEmail;
        private String _clienteTelefone;
        private String _clienteFoto;
        private String _clienteAvaliacao;

        public String ClienteID
        {
            get { return _clienteID; }
            set { _clienteID = value; }
        }

        public String ClienteNome
        {
            get { return _clienteNome; }
            set { _clienteNome = value;}
        }

        public String ClienteEmail
        {
            get { return _clienteEmail; }
            set { _clienteEmail = value;}
        }

        public String ClienteTelefone
        {
            get { return _clienteTelefone; }
            set { _clienteTelefone = value; }

        }

        public String ClienteFoto
        {
            get { return _clienteFoto;}
            set { _clienteFoto = value;}
        }

        public String ClienteAvaliacao
        {
            get { return _clienteAvaliacao; }
            set { _clienteAvaliacao = value; }

        }

       public Cliente(string clienteID, string clienteNome, string clienteEmail, string clienteTelefone, string clienteFoto, string clienteAvaliacao)
        {
            ClienteID = clienteID;
            ClienteNome = clienteNome;
            ClienteEmail = clienteEmail;
            ClienteTelefone = clienteTelefone;
            ClienteFoto = clienteFoto;
            ClienteAvaliacao = clienteAvaliacao;
        }
        public Cliente()
        {

        }

        public override string ToString()
        {
            return ClienteNome;
        }
    }
}
