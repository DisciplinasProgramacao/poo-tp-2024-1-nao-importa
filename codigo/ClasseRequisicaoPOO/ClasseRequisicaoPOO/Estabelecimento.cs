using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal  abstract class Estabelecimento
    {
        protected List<Requisicao> listaRequisicao;

        public abstract string mostrarSituacao();
        public abstract void requisicaoEntrada(Requisicao cliente);
        public abstract void requisicaoSaida(Requisicao cliente);
        public abstract string relatorioRequisicao(Requisicao clienteSaindo);
        public abstract string fecharConta(Requisicao cliente);
        public abstract void mostrarMenu();
        public abstract void mostrarItem();
    }
}
