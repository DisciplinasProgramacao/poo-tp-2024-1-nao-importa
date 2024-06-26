using System;
using System.Collections.Generic;
using System.Linq;

namespace ClasseRequisicaoPOO
{
    internal class Program
    {
        
        static void escolhaEstabelecimento()
        {
            Console.WriteLine("Escolha o Estabelecimento que deseja utilizar");
            Console.WriteLine("(R) - Restaurante");
            Console.WriteLine("(C) - Cafeteria");
            Console.WriteLine("(S) - Sair");
        }

        static void Main(string[] args)
        {
            char Estabelecimento = 'R';
            while (Estabelecimento != 'S')
            {
                try
                {
                    escolhaEstabelecimento();
                    Estabelecimento = char.ToUpper(char.Parse(Console.ReadLine()));

                    switch (Estabelecimento)
                    {
                        case 'R':
                            Restaurante restaurante = new Restaurante();
                            int opcaoRestaurante = 1;
                            int idRestaurante = 1;

                            while (opcaoRestaurante != 0)
                            {
                                try
                                {
                                    restaurante.mostrarMenu();
                                    opcaoRestaurante = int.Parse(Console.ReadLine());
                                    Console.Clear();

                                    switch (opcaoRestaurante)
                                    {
                                        
                                        case 0:
                                            break;
                                        case 1:
                                            Console.WriteLine("Informe o nome do cliente");
                                            string nomeRestaurante = Console.ReadLine();
                                            Console.WriteLine("Informe a quantidade de pessoas totais");
                                            int quantPessoas = int.Parse(Console.ReadLine());
                                            if (quantPessoas > 8)
                                            {
                                                Console.WriteLine("Quantidade não permitida");
                                                break;
                                            }
                                            else
                                            {
                                                Requisicao newClienteRestaurante = new Requisicao(restaurante, nomeRestaurante, idRestaurante, quantPessoas);
                                                idRestaurante++;
                                                newClienteRestaurante.entrada();
                                                Console.WriteLine();
                                                break;
                                            }
                                        case 2:
                                            Console.WriteLine("Escolha o número da mesa para liberá-la");
                                            Console.WriteLine(restaurante.mostrarSituacao());
                                            int numDaMesa = int.Parse(Console.ReadLine());

                                            var mesaEscolhidaLiberacao = restaurante.getMesa().FirstOrDefault(p => p.verificarNumeroMesa() == numDaMesa);
                                            if (mesaEscolhidaLiberacao == null || !mesaEscolhidaLiberacao.mesaEstaOcupada())
                                            {
                                                Console.WriteLine("A mesa já está liberada ou não existe.");
                                                break;
                                            }
                                            else
                                            {
                                                int numChave = mesaEscolhidaLiberacao.getIdCliente();

                                                var requisicaoCliente = restaurante.getRequisicao().FirstOrDefault(p => p.getId() == numChave);
                                                if (requisicaoCliente != null)
                                                {
                                                    restaurante.requisicaoSaida(requisicaoCliente);
                                                }

                                                Console.WriteLine();
                                                break;
                                            }
                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine(restaurante.mostrarSituacao());
                                            Console.WriteLine(" ");
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine(restaurante.mostrarFila());
                                            Console.WriteLine(" ");
                                            break;
                                        case 5:

                                            restaurante.mostrarItem();
                                            Console.WriteLine();
                                            Console.WriteLine("Escolha o item");
                                            int escolhaItemRestaurante = int.Parse(Console.ReadLine());
                                            if (escolhaItemRestaurante < 1 || escolhaItemRestaurante > 11)
                                            {
                                                Console.WriteLine("Não possuímos item com esse número no cardápio");
                                                break;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Qual mesa?");
                                                Console.WriteLine("-------------------------------------");
                                                Console.WriteLine(restaurante.mostrarSituacao());
                                                int optionMesa = int.Parse(Console.ReadLine());
                                                Console.Clear();

                                                var mesaEscolhida = restaurante.getMesa().FirstOrDefault(p => p.verificarNumeroMesa() == optionMesa);

                                                if (mesaEscolhida != null && mesaEscolhida.mesaEstaOcupada())
                                                {
                                                    mesaEscolhida.getclienteSentado().getPedido().adicionarItem(new CardapioRestaurante(escolhaItemRestaurante));
                                                    Console.WriteLine("Item adicionado");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Mesa inválida ou não está ocupada.");
                                                }
                                                break;
                                            }

                                        default:
                                            Console.WriteLine("Opção inválida.");
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                                }
                            }
                            break;

                        case 'C':
                            Cafeteria cafeteria = new Cafeteria();
                            int opcaoCafe = 1;
                            int idCafe = 1;

                            while (opcaoCafe != 0)
                            {
                                try
                                {
                                    cafeteria.mostrarMenu();
                                    opcaoCafe = int.Parse(Console.ReadLine());
                                    Console.Clear();

                                    switch (opcaoCafe)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            Console.WriteLine("Informe o nome do cliente");
                                            string nomeCafe = Console.ReadLine();
                                            Requisicao newClienteCafe = new Requisicao(cafeteria, nomeCafe, idCafe);
                                            idCafe++;
                                            newClienteCafe.entradaCafeteria();
                                            Console.WriteLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Escolha o número do cliente para liberá-lo");
                                            Console.WriteLine(cafeteria.mostrarSituacao());
                                            int numClienteCafe = int.Parse(Console.ReadLine());
                                            var clienteCafe = cafeteria.getRequisicao().FirstOrDefault(p => p.getId() == numClienteCafe);
                                            if (clienteCafe != null)
                                            {
                                                cafeteria.requisicaoSaida(clienteCafe);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cliente não encontrado.");
                                            }
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine(cafeteria.mostrarSituacao());
                                            Console.WriteLine(" ");
                                            break;
                                        case 4:

                                            cafeteria.mostrarItem();
                                            Console.WriteLine();
                                            Console.WriteLine("Escolha o item");
                                            int escolhaItemCafe = int.Parse(Console.ReadLine());
                                            if (escolhaItemCafe < 1 || escolhaItemCafe > 10)
                                            {
                                                Console.WriteLine("Não possuímos item com esse número no cardápio");
                                                break;
                                            }
                                            Console.Clear();

                                            Console.WriteLine("Escolha o número do cliente para adicionar ao pedido");
                                            Console.WriteLine(cafeteria.mostrarSituacao());
                                            int numClienteItemCafe = int.Parse(Console.ReadLine());
                                            Console.Clear();

                                            var clienteItemCafe = cafeteria.getRequisicao().FirstOrDefault(p => p.getId() == numClienteItemCafe);

                                            if (clienteItemCafe != null)
                                            {
                                                clienteItemCafe.getPedido().adicionarItem(new CardapioCafeteria(escolhaItemCafe));
                                                Console.WriteLine("Item adicionado");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cliente não encontrado.");
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Opção inválida.");
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                                }
                            }
                            break;

                        case 'S':
                            Console.WriteLine("Saindo do sistema...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }
            }
        }
    }
}
