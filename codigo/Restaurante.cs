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

        }
        public void requisicaoEntrada(Requisicao cliente)
        {
 
            if (verificarDisponibilidade() == true && verificarFilaEspera() == true)
            {
                criarMesa(cliente);
            }
            else
            {
                filaDeEspera.Enqueue(cliente);
            }

        }
        public void requisicaoSaida(Mesa cliente, DateTime dataHoraEntrada)
        {
            int id = cliente.verificarID();
            RetirarNaMesa(id);
            if (verificarFilaEspera() == false)
            {
                Requisicao proximodaFila = filaDeEspera.Dequeue();
                criarMesa(proximodaFila);
            }
            string relatorio = "ID do cliente: " + cliente.verificarID() + " Hora de saída: " + dataHoraEntrada;
            listaRequisicao.Add(relatorio);
        }
        public bool verificarDisponibilidade()
        {

            return true;
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
        private void criarMesa(Requisicao Cliente)
        {
            Mesa mesa = new Mesa();
            ColocarNaMesa(mesa);
        }
        private void ColocarNaMesa(Mesa mesa)
        {
            listaDeMesa.Add(mesa);
        }
        private void RetirarNaMesa(int id)
        {
            listaDeMesa.RemoveAt(id);
        }
        public string relatorioRequisicao()
        {
            return "teste";
        }
    }
}

