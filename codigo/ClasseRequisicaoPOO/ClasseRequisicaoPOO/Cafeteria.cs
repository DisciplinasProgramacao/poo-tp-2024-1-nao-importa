using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal  class Cafeteria : Estabelecimento
    {
        private List<Requisicao> listaRequisicao;

        public Cafeteria()
        {
            listaRequisicao = new List<Requisicao>();
        }
        public override string fecharConta(Requisicao cliente)
        {
            return cliente.getPedido().relatorio();
        }


        public override string mostrarSituacao()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listaRequisicao.Count; i++)
            {
                sb.Append("\n");
                sb.Append(listaRequisicao[i].getId());
                sb.Append(" - ");
                sb.Append(listaRequisicao[i].getNome());
                sb.Append("\n Pedido: ");
                sb.Append(listaRequisicao[i].getPedido().relatorio());
            }

            return sb.ToString();
        }


        public override string relatorioRequisicao(Requisicao clienteSaindo)
        {
            string retorno = "";
            retorno += "\n" + clienteSaindo.getNome() + " saindo do restaurante \n " + "Data e hora de entrada: " + clienteSaindo.getdataHoraEntrada().ToString() +
                "\n Data e hora de saída: " + DateTime.Now.ToString();
            return retorno;
        }

        public override void requisicaoEntrada(Requisicao cliente)
        {
            listaRequisicao.Add(cliente);
        }

        public override void requisicaoSaida(Requisicao cliente)
        {
            listaRequisicao.Remove(cliente);
            Console.WriteLine(relatorioRequisicao(cliente));
        }

        public override void mostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Bem-vindo à Cafeteria!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Chegada de Cliente");
            Console.WriteLine("2. Fechar conta de cliente");
            Console.WriteLine("3. Ver situação da cafeteria");
            Console.WriteLine("4. Adicionar item a um pedido");
            Console.WriteLine("0. Sair");
            Console.WriteLine("-------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            Console.WriteLine();
        }

        public override void mostrarItem()
        {
            Console.WriteLine("Comida:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" 1. Pão de queijo – R$ 5\n 2. Bolinha de cogumelo – R$ 7\n 3. Rissole de palmito – R$ 7\n 4. Coxinha de carne de jaca – R$ 4\n 5. Fatia de queijo de caju – R$ 9\n 6. Biscoito amanteigado – R$ 3\n 7. Cheesecake de frutas vermelhas - R$ 15");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Bebidas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" 8. Água – R$ 3\n 9. Copo de suco – R$ 7\n 10. Café espresso orgânico R$ 6");
            Console.ResetColor();
        }

        public List<Requisicao> getRequisicao()
        {
            return listaRequisicao;
        }
    }
}
