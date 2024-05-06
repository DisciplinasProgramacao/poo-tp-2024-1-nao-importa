using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
     internal class Mesa
    {
        private int numMesa;
        private int capacidade;
        private int idCliente;
        private bool estaOcupada;

        public Mesa(int numMesa, int capacidade)
        {
            this.numMesa = numMesa;
            this.capacidade = capacidade;
            this.idCliente = -1;
            this.estaOcupada = false;


        }
        public int verificarNumeroMesa()
        {
            return numMesa;
        }
        public void setIdCliente(int idCliente)
        {
            this.idCliente = idCliente;
        }
        public void setEstaOcupada(bool estaOcupada)
        {
            this.estaOcupada= estaOcupada;
        }
        public bool mesaEstaOcupada()
        {
            return this.estaOcupada;
        }
        public int getIdCliente() 
        {
            return idCliente; 
        }
        public int getCapacidade()
        {
            return capacidade;
        }
         
        public bool verificarAdequacao(Requisicao requisicao)
        {
            bool resposta = false;
            if (!estaOcupada && requisicao.obterQuantPessoas() <= capacidade)
            {
                resposta = true;
            }

            return resposta;
        }
        
    }
}
