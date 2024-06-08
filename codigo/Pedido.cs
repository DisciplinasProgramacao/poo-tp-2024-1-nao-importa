using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class Pedido
    {
         
        private const double taxaDeServico= 0.1;
        List<Item> listaItem;
        private double valorTotal;

        public Pedido()
        {
            valorTotal = 0;
            listaItem = new List<Item>();
            
        }
        public void adicionarItem(Item item)
        {
            listaItem.Add(item);
            valorTotal+=item.getValor();
        }
        public double calcularConta()
        {
            valorTotal = 0;
            for(int i = 0; i < listaItem.Count; i++)
            {
                valorTotal += listaItem[i].getValor();
            }
            valorTotal += (valorTotal * taxaDeServico);
            return valorTotal;

        }
        public string relatorio()
        {
             calcularConta();
             StringBuilder stringBuilder = new StringBuilder();
             StringBuilder SB = stringBuilder;

            for (int i = 0; i < listaItem.Count; i++)
            {
                SB.Append("- "+ listaItem[i].getNome() + " R$"+ listaItem[i].getValor().ToString() + "\n");
            }
            SB.Append("- Taxa de serviço R$" + (valorTotal*taxaDeServico).ToString("0.00") );
             SB.Append("\n"+ "Valor total do pedido: "+ "\n R$"+ valorTotal.ToString("0.00"));

            return SB.ToString();

        }
       
    }
}
