using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClasseRequisicaoPOO
{
    internal class Restaurante: Estabelecimento
    {
        private List<Requisicao> listaRequisicao;
        private List<Requisicao> filaDeEspera;
        private List<Mesa> listaDeMesa;

        public Restaurante()
        {
            listaRequisicao = new List<Requisicao>();
            filaDeEspera = new List<Requisicao>();
            listaDeMesa = new List<Mesa>{
              new Mesa(1,4),
              new Mesa(2,4),
              new Mesa(3,4),
              new Mesa(4,4),
              new Mesa(5,6),
              new Mesa(6,6),
              new Mesa(7,6),
              new Mesa(8,6),
              new Mesa(9,8),
              new Mesa(10,8),
            };
        }

        public string mostrarFila()
        {
            string retorno = "";
            if (filaDeEspera.Count > 0)
            {
                for (int i = 0; i < filaDeEspera.Count; i++)
                {
                    retorno += filaDeEspera[i].getNome() + " Esta na Fila \n";
                }
            }
            else
            {
                retorno = "Fila vazia";
            }


            return retorno;

        }

        public override string mostrarSituacao()
        {
            StringBuilder sb = new StringBuilder();

            var mesasUnicas = listaDeMesa.GroupBy(m => m.verificarNumeroMesa())
                                         .Select(g => g.First())
                                         .ToList();

            for (int i = 0; i < mesasUnicas.Count; i++)
            {
                sb.Append("\nMesa ----- ");
                sb.Append(mesasUnicas[i].verificarNumeroMesa());
                sb.Append(" - capacidade ");
                sb.Append(mesasUnicas[i].getCapacidade() + " Pessoas");

                if (mesasUnicas[i].mesaEstaOcupada())
                {
                    sb.Append(" - Esta ocupada\n");
                    sb.Append(mesasUnicas[i].getclienteSentado().getPedido().relatorio());
                }
                else
                {
                    sb.Append(" - Esta livre");
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }



        public override void requisicaoEntrada(Requisicao cliente)
        {
            if (verificarDisponibilidade(cliente) == true)
            {
                if (FilaEsperaLivre() == true)
                {
                    Console.WriteLine(ColocarNaMesa(cliente));
                    listaRequisicao.Add(cliente);

                }
            }
            else
            {
                Console.WriteLine(colocarNaFila(cliente));

            }
        }
        public override void requisicaoSaida(Requisicao cliente)
        {
            for (int i = 0; i < listaDeMesa.Count; i++)
            {
                if (listaDeMesa[i].getIdCliente() == cliente.getId())
                {
                    listaRequisicao.Remove(cliente);
                    Console.WriteLine(RetirarNaMesa(listaDeMesa[i]));
                    Console.WriteLine(verificarFila(listaDeMesa[i]));
                    Console.WriteLine(relatorioRequisicao(cliente));
                    break;
                }
            }
        }
        public bool verificarDisponibilidade(Requisicao cliente)
        {
            bool resposta = false;

            for (int i = 0; i < listaDeMesa.Count; i++)
            {
                if (listaDeMesa[i].verificarAdequacao(cliente) == true)
                {
                    resposta = true;
                    break;
                }
            }
            return resposta;
        }
        private bool FilaEsperaLivre()
        {
            bool resposta = false;

            if (filaDeEspera.Count() == 0)
            {
                resposta = true;
            }
            return resposta;
        }
        private string ColocarNaMesa(Requisicao cliente)
        {
            string retorno = "";
            if (verificarDisponibilidade(cliente) == true)
            {
                for (int i = 0; i < listaDeMesa.Count; i++)
                {
                    if (listaDeMesa[i].mesaEstaOcupada() == false && listaDeMesa[i].verificarAdequacao(cliente) == true)
                    {
                        listaDeMesa[i].setIdCliente(cliente.getId());
                        listaDeMesa[i].setEstaOcupada(true);
                        listaDeMesa[i].setclienteSentado(cliente);
                        retorno += "Cliente inserido em uma mesa\n";
                        break;

                    }
                }
            }
            return retorno;


        }

        private string RetirarNaMesa(Mesa mesa)
        {
            mesa.setEstaOcupada(false);
            mesa.setIdCliente(-1);
            return mesa.verificarNumeroMesa() + " Liberada\n";
        }
        public string verificarFila(Mesa mesa)
        {
            string retorno = "";
            for (int i = 0; i < filaDeEspera.Count; i++)
            {
                if (filaDeEspera[i].obterQuantPessoas() <= mesa.getCapacidade()) ;
                {
                    ColocarNaMesa(filaDeEspera[i]);
                    listaRequisicao.Add(filaDeEspera[i]);
                    retorno += filaDeEspera[i].getNome() + " foi direcionado da fila para o restaurante";
                    filaDeEspera.RemoveAt(i);
                    break;
                }
            }
            return retorno;
        }
        public override string relatorioRequisicao(Requisicao clienteSaindo)
        {
            string retorno = "";
            retorno += "\n" + clienteSaindo.getNome() + " saindo do restaurante \n " + "Data e hora de entrada: " + clienteSaindo.getdataHoraEntrada().ToString() +
                "\n Data e hora de saída: " + DateTime.Now.ToString();
            return retorno;
        }
        public string colocarNaFila(Requisicao cliente)
        {
            filaDeEspera.Add(cliente);
            return cliente.getNome() + " Direcionado para a fila";

        }
        public override string fecharConta(Requisicao cliente)
        {
            return cliente.getPedido().relatorio();
        }

        public override void mostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Bem-vindo ao restaurante!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Chegada de Cliente");
            Console.WriteLine("2. Liberar Mesa");
            Console.WriteLine("3. Ver situação das mesas");
            Console.WriteLine("4. Ver fila de espera");
            Console.WriteLine("5. Adicionar item a um pedido");
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
            Console.WriteLine(" 1. Moqueca de Palmito – R$ 32\n 2. Falafel Assado – R$ 20\n 3. Salada Primavera com Macarrão Konjac – R$ 25\n 4. Escondidinho de Inhame – R$ 18\n 5. Strogonoff de Cogumelos – R$ 35\n 6. Caçarola de legumes – R$ 22");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Bebidas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" 7. Água – R$ 3\n 8. Copo de suco – R$ 7\n 9. Refrigerante orgânico – R$ 7\n 10. Cerveja vegana – R$ 9\n 11. Taça de vinho vegano – R$ 18");
            Console.ResetColor();
        }

        public List<Mesa> getMesa()
        {
            return listaDeMesa;
        }
        public List<Requisicao> getRequisicao()
        {
            return listaRequisicao;
        }
    }
}

