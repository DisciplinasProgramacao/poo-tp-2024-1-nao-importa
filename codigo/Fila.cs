using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace docs.diagramas
{
    public class Fila
    {
        
        public Queue<Requisicao> requisicao = new Queue<Requisicao>();

        public Fila (){
            
        }
        
        public void addCliente(Requisicao cliente){
            requisicao.Enqueue(cliente);
        }

        void removerCliente(Requisicao cliente){
            requisicao.Denqueue(cliente);
        }

        public bool verificarFila(Requisicao cliente){
            
        }

    }
}