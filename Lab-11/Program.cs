using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                opcion = Pantallas.PantallaPrincipal();

                switch (opcion)
                {
                    case 1:
                        opcion = Pantallas.RegistrarUnaNota();
                        break;
                    case 2:
                        opcion = Pantallas.HallarNotaMayor();
                        break;
                    case 3:
                        opcion = Pantallas.HallarNotaMenor();
                        break;
                    case 4:
                        opcion = Pantallas.Encontrar();
                        break;
                    case 5:
                        opcion = Pantallas.Modificar();
                        break;
                    case 6:
                        opcion = Pantallas.VerNotas();
                        break;
                    case 0:
                        break;
                }
            } while (opcion != 7);
        }
    }
}
