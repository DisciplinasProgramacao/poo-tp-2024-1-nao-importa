using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class CardapioRestaurante : Cardapio
    {
        private int selecionado;

        public CardapioRestaurante(int selecionado)
        {
            this.selecionado = selecionado;
            switch (selecionado)
            {
                case 1:
                default:
                    nome = "Moqueca de palmito";
                    valor = 32;
                    break;
                case 2:
                    nome = "Falafel assado";
                    valor = 20;
                    break;
                case 3:
                    nome = "Salada primavera com macarrão Konjac";
                    valor = 25;
                    break;
                case 4:
                    nome = "Escondidinho de inhame";
                    valor = 18;
                    break;
                case 5:
                    nome = "Strogonoff de cogumelos";
                    valor = 35;
                    break;
                case 6:
                    nome = "Caçarola de legumes";
                    valor = 22;
                    break;
                case 7:
                
                    nome = "Água";
                    valor = 3;
                    break;
                case 8:
                    nome = "Copo de suco";
                    valor = 7;
                    break;
                case 9:
                    nome = "Refrigerante ogranico";
                    valor = 7;
                    break;
                case 10:
                    nome = "Cerveja veganda";
                    valor = 9;
                    break;
                case 11:
                    nome = "Taça de vinho vegano";
                    valor = 18;
                    break;


            }
        }
    }
}
