using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class CardapioCafeteria : Cardapio
    {
        private int selecionado;

        public CardapioCafeteria(int selecionado)
        {
            this.selecionado = selecionado;
            switch (selecionado)
            {
                case 1:
                default:
                    nome = "Pão de queijo";
                    valor = 5;
                    break;
                case 2:
                    nome = "Bolinha de cogumelo";
                    valor = 7;
                    break;
                case 3:
                    nome = "Rissole de palmito";
                    valor = 7;
                    break;
                case 4:
                    nome = "Coxinha de carne de jaca";
                    valor = 4;
                    break;
                case 5:
                    nome = "Fatia de queijo de caju ";
                    valor = 9;
                    break;
                case 6:
                    nome = "Biscoito amanteigado";
                    valor = 3;
                    break;
                case 7:
                    nome = "Cheesecake de frutas vermelhas";
                    valor = 15;
                    break;
                case 8:
                    nome = "Água";
                    valor = 3;
                    break;
                case 9:
                    nome = "Copo de suco";
                    valor = 7;
                    break;
                case 10:
                    nome = "Café espresso orgânico ";
                    valor = 6;
                    break;                

            }
        }
    }
}
