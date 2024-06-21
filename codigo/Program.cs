using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            int opcao = 1;
            int id = 1;
            while (opcao != 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Bem-vindo ao restaurante!");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1. Chegada de Cliente");
                Console.WriteLine("2. Liberar Mesa");
                Console.WriteLine("3. Ver situação das mesas");
                Console.WriteLine("4. Ver fila de espera");
                Console.WriteLine("5. Adicionar item a um pedido");
                Console.WriteLine("0. Sair");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");
                Console.WriteLine();
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                if(opcao == 1)
                {
                    Console.WriteLine("Infome o nome do cliente");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Informe a quantidade de pessoas totais");
                    int quantPessoas = int.Parse(Console.ReadLine());
                    Requisicao newCliente = new Requisicao(restaurante, nome,id, quantPessoas);
                    id++;
                    newCliente.entrada();
                    Console.WriteLine();
                    


                } 
                else if (opcao == 2)
                {
                    Console.WriteLine("Escolha o número da mesa para libera-la");
                    Console.WriteLine(restaurante.mostrarSituacaoRestaurante());                    
                    int numDaMesa= int.Parse(Console.ReadLine());
                    int numChave = 0;
                    for (int i = 0; i < restaurante.listaDeMesa.Count; i++)
                    {
                        if (restaurante.listaDeMesa[i].verificarNumeroMesa() == numDaMesa )
                        {
                             numChave = restaurante.listaDeMesa[i].getIdCliente();
                            break;
                        }
                    }
                    for (int i = 0; i < restaurante.listaRequisicao.Count; i++)
                    {
                        if (restaurante.listaRequisicao[i].getId() == numChave)
                        {
                            restaurante.requisicaoSaida(restaurante.listaRequisicao[i]);
                            break;
                        }
                    }
                    Console.WriteLine();

                }
                else if(opcao==3)
                {
                    Console.Clear();
                    Console.WriteLine(restaurante.mostrarSituacaoRestaurante());
                    Console.WriteLine(" ");
                }
                else if(opcao == 4)
                {
                    Console.Clear();
                    Console.WriteLine(restaurante.mostrarFila());
                    Console.WriteLine(" ") ;
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("1- Comida\n2- Bebida");
                    int comidaOubebida= int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (comidaOubebida == 1)
                    {
                        Console.WriteLine("Comidas:\r\n 1. Moqueca de Palmito – R$ 32\r\n 2. Falafel Assado – R$ 20\r\n 3. Salada Primavera com Macarrão Konjac – R$ 25\r\n 4. Escondidinho de Inhame – R$ 18\r\n 5. Strogonoff de Cogumelos – R$ 35\r\n 6. Caçarola de legumes – R$ 22");
                    }
                    else
                    {
                        Console.WriteLine(" Bebidas:\r\n 1. Água – R$ 3\r\n 2. Copo de suco – R$ 7\r\n 3. Refrigerante orgânico – R$ 7\r\n 4. Cerveja vegana – R$ 9\r\n 5. Taça de vinho vegano – R$ 18");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Esolha o item");
                    int escolhaItem=int.Parse(Console.ReadLine());
                    Console.Clear();



                    if (comidaOubebida == 1)
                    {
                        Console.WriteLine("Mostrando situação do restaurante (comida)");
                        Console.WriteLine("Qual mesa?");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine(restaurante.mostrarSituacaoRestaurante());                       
                        int optionMesa = int.Parse(Console.ReadLine());
                        Console.Clear();
                        
                        for (int i = 0; i < restaurante.listaDeMesa.Count; i++)
                        {
                            if (restaurante.listaDeMesa[i].verificarNumeroMesa() == optionMesa)
                            {
                                optionMesa = restaurante.listaDeMesa[i].getIdCliente();
                                break;
                            }
                        }
                        for (int i = 0; i < restaurante.listaRequisicao.Count; i++)
                        {
                            if (restaurante.listaRequisicao[i].getId() == optionMesa)
                            {
                                restaurante.listaRequisicao[i].pedido.adicionarItem(new Comida(escolhaItem));
                                break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("Item adicionado");
                    }
                    else
                    {
                        Console.WriteLine("Mostrando situação do restaurante (bebida)");
                        Console.WriteLine("Qual mesa?");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine(restaurante.mostrarSituacaoRestaurante());
                        int optionMesa = int.Parse(Console.ReadLine());
                        
                        Console.Clear();
                        for (int i = 0; i < restaurante.listaDeMesa.Count; i++)
                        {
                            if (restaurante.listaDeMesa[i].verificarNumeroMesa() == optionMesa)
                            {
                                optionMesa = restaurante.listaDeMesa[i].getIdCliente();
                                break;
                            }
                        }
                        for (int i = 0; i < restaurante.listaRequisicao.Count; i++)
                        {
                            if (restaurante.listaRequisicao[i].getId() == optionMesa)
                            {
                                restaurante.listaRequisicao[i].pedido.adicionarItem(new Bebida(escolhaItem));
                                break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("Item adicionado");
                    }
                    

                }
                
                
            }
            Console.ReadLine();
        }
    }
}
