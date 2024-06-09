using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class Bebida : Item
    {
        private int selecionado;

        public Bebida(int selecionado)
        {
            this.selecionado = selecionado;
            switch (selecionado)
            {
                case 1:
                default:
                    nome = "Água";
                    valor = 3;
                    break;
                case 2:
                    nome = "Copo de suco";
                    valor = 7;
                    break;
                case 3:
                    nome = "Refrigerante ogranico";
                    valor = 7;
                    break;
                case 4:
                    nome = "Cerveja veganda";
                    valor = 9;
                    break;
                case 5:
                    nome = "Taça de vinho vegano";
                    valor = 18;
                    break;


            }
        }
    }
}
