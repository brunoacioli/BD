using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class PontoRecarga
    {
        private String _RecargaID;
        private String _RecargaEmpresa;
        private String _RecargaCapacidade;
        private String _RecargaDisponibilidade;
        private String _RecargaMorada;

        public String RecargaID
        {
            get { return _RecargaID; }  
            set { _RecargaID = value;}
        }

        public String RecargaEmpresa
        {
            get { return _RecargaEmpresa; }
            set { _RecargaEmpresa = value;}
        }

        public String RecargaCapacidade
        {
            get { return _RecargaCapacidade; }
            set { _RecargaCapacidade = value; }
        }

        public String RecargaDisponibilidade
        {
            get { return _RecargaDisponibilidade; }
            set { _RecargaDisponibilidade = value; }
        }
        public String RecargaMorada
        {
            get { return _RecargaMorada; }
            set { _RecargaMorada = value;}
        }

        public PontoRecarga(string recargaID, string recargaEmpresa, string recargaCapacidade, string recargaDisponibilidade, string recargaMorada)
        {
            RecargaID = recargaID;
            RecargaEmpresa = recargaEmpresa;
            RecargaCapacidade = recargaCapacidade;
            RecargaDisponibilidade = recargaDisponibilidade;
            RecargaMorada = recargaMorada;
            
        }

        public PontoRecarga()
        {

        }

        public override string ToString()
        {
            return RecargaEmpresa;
        }
    }
}
