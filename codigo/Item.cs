using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseRequisicaoPOO
{
    internal class Item
    {
        protected int valor;
        protected string nome;
        
        public int getValor()
        {
            return valor;
            
        }
        public string getNome() {
            return nome;
        }
    }
}
