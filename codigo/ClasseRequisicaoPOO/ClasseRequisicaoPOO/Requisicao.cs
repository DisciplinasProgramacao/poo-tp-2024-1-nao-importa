using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class Requisicao:Cliente
    {
        
        private int quantPessoas;
        Restaurante restaurante;
        private DateTime dataHoraEntrada;
        private Pedido pedido;
        Cafeteria Cafeteria;

        public Requisicao(Restaurante restaurante,string nome, int Id, int quantPessoas) : base(nome, Id)
        {
            this.restaurante = restaurante;
            this.quantPessoas = quantPessoas;
            this.dataHoraEntrada= DateTime.Now;
            pedido= new Pedido();
        }
        public Requisicao(Cafeteria cafeteria,string nome, int Id):base(nome, Id) 
        {
            this.Cafeteria = cafeteria;
            this.dataHoraEntrada = DateTime.Now;
            pedido = new Pedido();
        }

        public void entrada()
        {
             
             restaurante.requisicaoEntrada(this);

        }
        public void entradaCafeteria()
        {
            Cafeteria.requisicaoEntrada(this);
        }
        
        
        public int obterQuantPessoas()
        {           
             return quantPessoas;           
        }
        public int getId()
        {
            return id;
        }

        public Pedido getPedido()
        {
            return pedido;
        }

        public DateTime getdataHoraEntrada()
        {
            return dataHoraEntrada;
        }
    }
}
