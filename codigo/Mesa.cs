using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Mesa
    {
        private int numMesa;
        private int capacidade;
        protected int idCliente;

        public Mesa ( int numMesa, int capacidade)
        {
            this.numMesa = numMesa;
            this.capacidade = capacidade;
            this.idCliente = -1;

        }
        public string relatorio()
        {
            return "teste";
        }

        public bool verificarAdequacao( Requisicao requisicao )
        {
            bool resposta = false;
            if ( idCliente == -1 && requisicao.qntPessoas <= capacidade)
            {
                resposta = true;
            }

            return resposta;
        }


    }
}
