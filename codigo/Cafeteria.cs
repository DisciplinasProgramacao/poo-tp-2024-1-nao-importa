using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal  class Cafeteria : Estabelecimento
    {
        public List<Requisicao> listaRequisicao;

        public Cafeteria()
        {
            listaRequisicao = new List<Requisicao>();
        }
        public override string fecharConta(Requisicao cliente)
        {
            return cliente.pedido.relatorio();
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
                sb.Append(listaRequisicao[i].pedido.relatorio());
            }

            return sb.ToString();
        }


        public override string relatorioRequisicao(Requisicao clienteSaindo)
        {
            string retorno = "";
            retorno += "\n" + clienteSaindo.getNome() + " saindo do restaurante \n " + "Data e hora de entrada: " + clienteSaindo.dataHoraEntrada.ToString() +
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
    }
}
