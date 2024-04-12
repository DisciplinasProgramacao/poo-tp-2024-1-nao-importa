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

        public Requisicao(Cliente cliente, int quantPessoas) : base(cliente.Nome, cliente.Id, cliente.Cpf)
        {
            this.quantPessoas = quantPessoas;
        }

        public void entrada()
        {
            DateTime dataHoraEntrada = DateTime.Now;
            Restaurante newCliente = new Restaurante();
             newCliente.requisicaoEntrada(this, dataHoraEntrada);

        }
        public void saida()
        {
            DateTime dataHoraSaida = DateTime.Now;
            Restaurante newCliente = new Restaurante();
            newCliente.requisicaoSaida(this, dataHoraSaida);
        }

        public int obterQuantPessoas()
        {
            if (quantPessoas > 0)
            {
                return quantPessoas;
            }
            else
            {
                throw new Exception("Quantidade de pessoas inváido");
            }
        }
    }
}
