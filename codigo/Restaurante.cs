using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    internal class Restaurante
    {
       
        private List<string> listaRequisicao;
        private Queue<Requisicao> filaDeEspera;
        private List<Mesa> listaDeMesa;

        public Restaurante()
        {
            filaDeEspera = new Queue<Requisicao>();
            listaDeMesa = new List<Mesa>();
        }
         public void requisicaoEntrada(Requisicao cliente)
         {
 
            if (verificarDisponibilidade(cliente) == true && verificarFilaEspera() == true)
            {
                ColocarNaMesa(cliente);
            }
            else
            {
                filaDeEspera.Enqueue(cliente);
            }

         }
        public void requisicaoSaida(Mesa cliente, DateTime dataHoraEntrada)
        {
            int numeroMesa = cliente.verificarNumeroMesa();
            RetirarNaMesa(numeroMesa);
            if (verificarFilaEspera() == false)
            {
                Requisicao proximodaFila = filaDeEspera.Dequeue();
                ColocarNaMesa(proximodaFila);
            }
            string relatorio = "Cliente da mesa: " + cliente.verificarNumeroMesa() + " Hora de saída: " + dataHoraEntrada;
            listaRequisicao.Add(relatorio);
        }
        public bool verificarDisponibilidade(Requisicao cliente)
        {
            bool resposta = false;
            
            for (int i =0; i<listaDeMesa.Count;i++)
            {
                if (listaDeMesa[i].verificarAdequacao(cliente) == true )
                {
                    resposta = true;
                }
            }
            return resposta;
        }
        private bool verificarFilaEspera()
        {
            bool resposta = false;

            if (filaDeEspera.Count() == 0)
            {
                resposta = true;
            }
            return resposta;
        }     
        public void criarMesa(int numeroDaMesa, int capacidade)
        {
            if (listaDeMesa.Count() < 10)
            {
                Mesa mesa = new Mesa(numeroDaMesa, capacidade);
                listaDeMesa.Add(mesa);
            }
            else
            {
                throw new Exception("Máximo de mesa criada");
            }
        }
        private void ColocarNaMesa(Requisicao Cliente)
        {
            listaDeMesa[1].alterarID(Cliente.Id);
          
        }

        private void RetirarNaMesa(int numeroMesa)
        {
            listaDeMesa.RemoveAt(numeroMesa);
        }
        public string relatorioRequisicao()
        {
            return "teste";
        }
    }
}

