using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClasseRequisicaoPOO
{
    internal class Restaurante
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


            return retorno;

        }
        public string mostrarSituacaoRestaurante()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < listaDeMesa.Count; i++)
            {
                sb.Append("\n");
                sb.Append("Mesa ");
                sb.Append(listaDeMesa[i].verificarNumeroMesa());
                sb.Append(" - capacidade ");
                sb.Append(listaDeMesa[i].getCapacidade() + " Pessoas");
                if (listaDeMesa[i].mesaEstaOcupada())
                {
                    sb.Append(" - Esta ocupada");
                }
                else
                {
                    sb.Append(" - Esta livre");
                }
            }

            return sb.ToString();
        }

        public void requisicaoEntrada(Requisicao cliente)
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
        public void requisicaoSaida(Requisicao cliente)
        {
            for (int i = 0; i < listaDeMesa.Count; i++)
            {
                if (listaDeMesa[i].getIdCliente() == cliente.getId())
                {
                    listaRequisicao.Remove(cliente);
                    Console.WriteLine(RetirarNaMesa(listaDeMesa[i]));
                    Console.WriteLine(verificarFila(listaDeMesa[i]));
                    Console.WriteLine(relatorioRequisicao(cliente));
                   
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
                        retorno += "Cliente inserido em uma mesa\n";
                      

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
                   
                }
            }
            return retorno; ;
        }
        public string relatorioRequisicao(Requisicao clienteSaindo)
        {
            string retorno = "";
            retorno += "\n" + clienteSaindo.getNome() + " saindo do restaurante \n " + "Data e hora de entrada: " + clienteSaindo.dataHoraEntrada.ToString() +
                "\n Data e hora de saída: " + DateTime.Now.ToString();
            return retorno;
        }
        public string colocarNaFila(Requisicao cliente)
        {
            filaDeEspera.Add(cliente);
            return cliente.getNome() + " Direcionado para a fila";

        }
    }
}
