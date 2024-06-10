using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class Comida : Item
    {
        private int selecionado;

        public Comida(int selecionado)
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


            }
        }
    }
}
