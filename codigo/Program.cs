using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11L_
{
    class Program
    {      

        static void Main(string[] args)
        {
            //Cliente c = new Cliente();
            //Restaurante r = new Restaurante();
            //Requisucao r1 = new Requisucao();

            string nome;
            string id;
            string cpf;

            Console.WriteLine("Informe o nome");
            nome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Informe o CPF");
            cpf = Console.ReadLine();

            nome.Trim();
            cpf.Trim();

            if (cpf.Length == 11)
            {

            }

            if (nome.Length > 3)
            {

            }
            
            Console.ReadLine();
        }
    }
}
