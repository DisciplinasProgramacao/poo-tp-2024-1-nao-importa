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
        public static void LetraCor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void CancelarCor()
        {
            Console.ResetColor();
        }

        public static void ListaDeOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            LetraCor();
            Console.WriteLine("(1) Alocar Cliente ");
            Console.WriteLine("(2) Liberar Mesa ");
            Console.WriteLine("(3) Liste ocupação da mesa");
            Console.WriteLine("(4) Olhar fila de espera ");
            Console.WriteLine("(5) Sair");
            CancelarCor();
            Console.WriteLine();
        }

        public static bool ContemNumero(string letra)
        {
            int i = 0;
            bool contemNumero = false;

            while (i < letra.Length)
            {
                if (char.IsDigit(letra[i]) == true)
                {
                    contemNumero = true;
                    break;
                }
                i++;
            }

            return contemNumero;
        }

        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            int id = 1;
            int opcao = 1;

            while (opcao != 5)
            {
                ListaDeOpcoes();
                Console.Write("Ler opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (opcao == 1)
                {
                    string nome = "";

                    while (nome.Length < 3 || ContemNumero(nome) == true) 
                    {
                        Console.Write("Informe o nome: ");
                        nome = Console.ReadLine();
                        nome.Trim();
                        Console.WriteLine();
                    }

                    int quantPessoa = -1;

                    while (quantPessoa < 0)
                    {
                        Console.Write("Informe a quantidade de pessoas : ");
                        quantPessoa = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }

                    Requisicao r = new Requisicao(restaurante, nome, id, quantPessoa);
                    id++;
                    r.entrada();
                    Console.WriteLine();
                }
                else if (opcao == 2)
                {
                    Console.WriteLine(restaurante.mostrarSituacaoRestaurante());
                    Console.WriteLine("Escolha o número da mesa que deseja libera-la");
                    int numeroDamesa = int.Parse(Console.ReadLine());
                    int idChave = 0;

                    for(int i = 0; i < restaurante.listaDeMesa.Count; i++)
                    {
                        if (restaurante.listaDeMesa[i].verificarNumeroMesa() == numeroDamesa)
                        {
                            idChave = restaurante.listaDeMesa[i].getIdCliente();
                            break;
                        }
                    }
                    for(int i = 0; i < restaurante.listaRequisicao.Count; i++)
                    {
                        if (restaurante.listaRequisicao[i].getId() == idChave)
                        {
                            restaurante.requisicaoSaida(restaurante.listaRequisicao[i]);
                            break;
                        }
                    }
                    Console.WriteLine();
                }
                else if (opcao == 3)
                {
                    Console.WriteLine(restaurante.mostrarSituacaoRestaurante());
                    Console.WriteLine();
                }
                else if (opcao == 4)
                {
                    Console.WriteLine(restaurante.mostrarFila());
                    Console.WriteLine();
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("° Obrigado ");
                }
                else
                {
                    Console.WriteLine("    Opção Inválida");
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
