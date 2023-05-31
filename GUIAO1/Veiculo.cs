using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class Veiculo
    {
        private String _veiculoID;
        private String _veiculoMarca;
        private String _veiculoModelo;
        private String _veiculoCor;
        private String _veiculoLugares;
        private String _veiculoMatricula;
        private String _veiculoCapacidadeBateria;

        public String VeiculoID
        {
            get { return _veiculoID; }
            set { _veiculoID = value;}
        }

        public String VeiculoMarca
        {
            get { return _veiculoMarca; }
            set { _veiculoMarca = value;}
        }
        public String VeiculoModelo
        {
            get { return _veiculoModelo; }
            set { _veiculoMarca = value; }
        }

        public String VeiculoCor
        {
            get { return _veiculoCor; }
            set { _veiculoCor = value;}
        }

        public String VeiculoLugares
        {
            get { return _veiculoLugares; }
            set { _veiculoLugares = value;}
        }

        public String VeiculoMatricula
        {
            get { return _veiculoMatricula; }
            set { _veiculoMatricula = value; }
        }

        public String VeiculoCapacidadeBateria
        {
            get { return _veiculoCapacidadeBateria; }
            set { _veiculoCapacidadeBateria = value; }
        }

        public Veiculo(string veiculoID, string veiculoMarca, string veiculoModelo, string veiculoCor, string veiculoLugares, string veiculoMatricula, string veiculoCapacidadeBateria)
        {
            VeiculoID = veiculoID;
            VeiculoMarca = veiculoMarca;
            VeiculoCor = veiculoCor;
            VeiculoLugares = veiculoLugares;
            VeiculoMatricula = veiculoMatricula;
            VeiculoCapacidadeBateria = veiculoCapacidadeBateria;
        }

        public Veiculo()
        {

        }

        public override string ToString()
        {
            return VeiculoMarca + " - " + VeiculoModelo;
        }

    }
}
