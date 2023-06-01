using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAO1
{
    public class Corrida
    {
        public String id;
        public String partida;
        public String destino;
        public String inicio;
        public String fim;
        public String duracao;
        public String pagamento;
        public String gorjeta;
        public String id_cliente;
        public String id_motorista;
        public String status;


        public Corrida(String id, String partida, String destino, String inicio, String fim, String duracao, String pagamento,String gorjeta, String id_cliente, String id_motorista, String status)
        {
            this.id = id;
            this.partida = partida;
            this.destino = destino;
            this.inicio = inicio;
            this.fim = fim;
            this.duracao = duracao;
            this.pagamento = pagamento;
            this.gorjeta= gorjeta;
            this.id_cliente = id_cliente;
            this.id_motorista= id_motorista;
            this.status = status;
        }

        public Corrida() { }

        public override string ToString()
        {
            return this.partida + " - " +this.destino + " - " + this.pagamento + "€";
        }

    }
}
