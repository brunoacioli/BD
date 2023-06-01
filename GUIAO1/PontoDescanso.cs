using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class PontoDescanso
    {
        private String _DescansoID;
        private String _DescansoAvaliacao;
        private String _DescansoNome;

        public String DescansoID
        {
            get { return _DescansoID; } 
            set { _DescansoID = value;}
        }
        public String DescansoAvaliacao
        {
            get { return _DescansoAvaliacao; }
            set { _DescansoAvaliacao = value; }
        }

        public String DescansoNome
        {
            get { return _DescansoNome; }
            set { _DescansoNome = value; }
        }
        public PontoDescanso(string descansoID,string descansoAvaliacao, string descansoNome)
        {
            DescansoID = descansoID;
            DescansoAvaliacao = descansoAvaliacao;
            DescansoNome = descansoNome;            
        }       

        public PontoDescanso() { }

        public override string ToString()
        {
            return DescansoNome;
        }
    }
}
