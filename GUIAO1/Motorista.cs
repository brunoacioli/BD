using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class Motorista
    {
        private String _motoristaID;
        private String _motoristaNome;
        private String _motoristaEmail;
        private String _motoristaTelefone;
        private String _motoristaFoto;
        private String _motoristaAvaliacao;
        private String _motoristaCartaConducao;

        public String MotoristaID
        {
            get { return _motoristaID; }
            set { _motoristaID = value; }
        }

        public String MotoristaNome
        {
            get { return _motoristaNome; }
            set { _motoristaNome = value;}
        }

        public String MotoristaEmail
        {
            get { return _motoristaEmail; }
            set { _motoristaEmail = value;}
        }

        public String MotoristaTelefone
        {
            get { return _motoristaTelefone; }
            set { _motoristaTelefone = value; }

        }

        public String MotoristaFoto
        {
            get { return _motoristaFoto;}
            set { _motoristaFoto = value;}
        }

        public String MotoristaAvaliacao
        {
            get { return _motoristaAvaliacao; }
            set { _motoristaAvaliacao = value; }

        }

        public String MotoristaCartaConducao
        {
            get { return _motoristaCartaConducao; }
            set { _motoristaCartaConducao = value; }
        }

       public Motorista(string motoristaID, string motoristaNome, string motoristaEmail, string motoristaTelefone, string motoristaFoto, string motoristaAvaliacao, string motoristaCartaConducao)
        {
            MotoristaID = motoristaID;
            MotoristaNome = motoristaNome;
            MotoristaEmail = motoristaEmail;
            MotoristaTelefone = motoristaTelefone;
            MotoristaFoto = motoristaFoto;
            MotoristaAvaliacao = motoristaAvaliacao;
            MotoristaCartaConducao = motoristaCartaConducao;
            MotoristaID = motoristaID;
            MotoristaNome = motoristaNome;
            MotoristaEmail = motoristaEmail;
            MotoristaTelefone = motoristaTelefone;
            MotoristaFoto = motoristaFoto;
            MotoristaAvaliacao = motoristaAvaliacao;
            MotoristaCartaConducao = motoristaCartaConducao;
        }
        public Motorista()
        {

        }

        public override string ToString()
        {
            return MotoristaNome;
        }
    }
}
