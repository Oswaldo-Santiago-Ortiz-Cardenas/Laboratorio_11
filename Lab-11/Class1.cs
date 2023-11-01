using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    public class Operaciones
    {
        public static int getEntero(string prefijo, string reemplazo)
        {
            int respuesta = 0;
            bool correcto = false;
            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = int.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.Clear();
                    Console.WriteLine(reemplazo);
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;

        }

        public static float getDecimal(string prefijo)
        {
            float respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = float.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;
        }

        public static string getTextoPantalla(string prefijo)
        {
            Console.Write(prefijo);
            return Console.ReadLine();
        }
    }
    public class Pantallas
    {
        public static float[] notas = new float[7];
        public static int contador = 0;

        public static int PantallaPrincipal()
        {
            Console.Clear();
            string texto = "" +
                "================================\n" +
                "Casos con arreglos\n" +
                "================================\n" +
                "1: Registrar notas\n" +
                "2: Hallar la nota mayor\n" +
                "3: Hallar la nota menor\n" +
                "4: Encontrar una nota\n" +
                "5: Modificar una nota\n" +
                "6: Ver notas registradas\n" +
                "7: Salir\n" +
                "================================\n";
            Console.Write(texto);
            return Operaciones.getEntero("Ingrese una opción: ", texto);


        }



        public static int RegistrarUnaNota()
        {
            int na = contador + 1;
            Console.Clear();
            string texto = "" +
                "================================\n" +
                "Registrar una nota\n" +
                "================================\n";
            Console.Write(texto);
            float calificación = Operaciones.getDecimal("Ingresa la nota Nro "+na + ": ");
            if(contador == 7)
            {
                Console.Write("Las notas ya estan llenas");
                Console.ReadKey();
                PantallaPrincipal();
            }
            else
            {
                notas[contador] = calificación;
                contador++;
            }

           string texto2 = "================================\n" +
                "1: Registrar otra nota\n" +
                "2: Regresar\n";

            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) 
            {
                return RegistrarUnaNota();
            }
            else
            {
                PantallaPrincipal();
            }
            return opcion;
        }


        public static int HallarNotaMayor()
        {
            Console.Clear();

            string texto = "================================\n" +
                "La nota mayor\n" +
                "================================";
            Console.WriteLine(texto);

            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS TODAVÍA");
            }
            else
            {
                float mayor = notas[0];
                int indexMayor = 0;

                for (int i = 1; i < contador; i++)
                {
                    if (notas[i] > mayor)
                    {
                        mayor = notas[i];
                        indexMayor = i;
                    }
                }

                
                Console.Write("La nota mayor es :" + mayor + "\n");
                for (int i = 0; i < contador; i++)
                {
                    if (i == indexMayor)
                    {
                        Console.Write("[" + mayor + "] ");
                    }
                    else
                    {
                        Console.Write(notas[i] + " ");
                    }
                }
            }

            string texto2 = "\n================================\n" +
                "1: Regresar\n";
            Console.WriteLine(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción:", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }
        public static int HallarNotaMenor()
        {

            Console.Clear();

            string texto = "================================\n" +
                "La nota menor\n" +
                "================================";
            Console.WriteLine(texto);

            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS TODAVÍA");
            }
            else
            {
                float menor = notas[0];
                int indexMenor = 0;

                for (int i = 1; i < contador; i++)
                {
                    if (notas[i] < menor)
                    {
                        menor = notas[i];
                        indexMenor = i;
                    }
                }


                Console.Write("La nota menor es :" + menor + "\n");
                for (int i = 0; i < contador; i++)
                {
                    if (i == indexMenor)
                    {
                        Console.Write("[" + menor + "] ");
                    }
                    else
                    {
                        Console.Write(notas[i] + " ");
                    }
                }
            }

            string texto2 = "\n================================\n" +
                "1: Regresar\n";
            Console.WriteLine(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción:", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }
        public static int Encontrar()
        {
            Console.Clear();
            string texto = "================================\n" +
                           "Buscar nota\n" +
                           "================================\n" +
                           "Ingrese la nota a buscar: ";
            if (contador == 0)
            {
                Console.WriteLine("NO HAY NOTAS PARA ENCONTRAR");
            }
            else
            {

                string valornota = Operaciones.getTextoPantalla(texto);
                int posicionEncontrada = -1;

                for (int i = 0; i < contador; i++)
                {

                    if (valornota == notas[i].ToString())
                    {
                        posicionEncontrada = i;
                        break;
                    }
                }

                if (posicionEncontrada != -1)
                {
                    Console.Write($"La nota está en la posición {posicionEncontrada}\n");

                    for (int i = 0; i < contador; i++)
                    {
                        if (i == posicionEncontrada)
                        {
                            Console.WriteLine($"{i} -> [{valornota}]");
                        }
                        else
                        {
                            Console.WriteLine($"{i} -> {notas[i]}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("La nota no se encontró en el arreglo.\n");
                }
            }
            string texto2 = "================================\n" +
                            "1: Regresar";
            Console.WriteLine(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1)
            {
                return 0;
            }
            return opcion;
        }

    

        public static int Modificar()
        {
            Console.Clear();
            string texto = "" +
                "================================\n" +
                "Modificar nota\n" +
                "================================\n" +
                "Ingrese la posición: 3\n" +
                "Ingrese el nuevo valor: 19\n" +
                "================================\n" +
                "Antes:15 16 18 [10] 12 15 13\n" +
                "Después:15 16 18 [19] 12 15 13\n" +
                "================================\n" +
                "1: Regresar\n";

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;

        }

        public static int VerNotas()
        {
            Console.Clear();
            string texto = "" +
                "================================\n\r" +
                "Notas Registradas\n\r" +
                "================================\n\r" +
                "Notas actuales: \n";
            Console.Write(texto);

            for (int i = 0; i < contador; i++)
            {
                Console.Write(+notas[i] + "-");
            }

            Console.WriteLine("");
            string texto2 = "================================\n\r" +
                "1: Regresar\n\r";

            Console.Write(texto2);
            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;

        }



    }

}

    

        


        