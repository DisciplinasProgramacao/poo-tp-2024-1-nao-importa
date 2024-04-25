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
        public DateTime dataHoraEntrada;

        public Requisicao(Restaurante restaurante,string nome, int Id, int quantPessoas) : base(nome, Id)
        {
            this.restaurante = restaurante;
            this.quantPessoas = quantPessoas;
            this.dataHoraEntrada= DateTime.Now;
        }

        public void entrada()
        {
             
             restaurante.requisicaoEntrada(this);

        }
        
        
        public int obterQuantPessoas()
        {           
             return quantPessoas;           
        }
        public int getId()
        {
            return id;
        }
    }
}

