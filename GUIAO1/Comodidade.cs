using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class Comodidade
    {
        private String _ComodidadeID;
        private String _ComodidadeTipo;

        public String ComodidadeID
        {
            get { return _ComodidadeID; }
            set { _ComodidadeID = value;}
        }

        public String ComodidadeTipo
        {
            get { return _ComodidadeTipo; }
            set { _ComodidadeTipo = value; }

        }

        public Comodidade()
        {

        }

        public Comodidade(string comodidadeID, string comodidadeTipo)
        {
            ComodidadeID = comodidadeID;
            ComodidadeTipo = comodidadeTipo;
        }

        public override string ToString()
        {
            return ComodidadeTipo;
        }
    }
}
