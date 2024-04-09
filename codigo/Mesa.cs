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
        private bool disponivel;
        private int capacidade;

        public Mesa ( int numMesa, bool disponivel, int capacidade)
        {
            this.numMesa = numMesa;
            this.disponivel = disponivel;
            this.capacidade = capacidade;

        }
        public string relatorio()
        {
            return "teste";
        }

        public bool verificarAdequacao( Requisicao requisicao )
        {
            bool resposta = false;
            if ( disponivel == true && requisicao.numAcompanhante <= capacidade)
            {
                resposta = true;
            }

            return resposta;
        }


    }
}
