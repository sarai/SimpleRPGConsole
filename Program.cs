using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Opcion Opcion1 = new Opcion("Entras en una tienda de artículos de repostería.");
            Opcion Opcion2 = new Opcion("Caminas al estante mas cercano.");
            Opcion Opcion3 = new Opcion("Sales de la tienda y te vas sin haber gastado un cinco.");

            Connect(Opcion1, Opcion2, "Te quedas y dices 'nada mas ando viendo'");
            Connect(Opcion1, Opcion3, "Te vas.");

            Opcion Opcion4 = new Opcion("Hay una exhibicion de crema para batir RICHS!");
            Opcion Opcion5 = new Opcion("El estante esta lleno de moledes con descuento!");
            Opcion Opcion6 = new Opcion("La persona atendiendo en ese pasillo te asusta!");

            Connect(Opcion2, Opcion4, "Sacas tu celular para empezar a grabar.");
            Connect(Opcion2, Opcion5, "Miras los moldes con el tamaño mas interesante para ti.");
            Connect(Opcion2, Opcion6, "Notas a la segunda persona atendiendo.");

            Connect(Opcion4, Opcion3, "Vas acomprar un litro de crema para batir.");
            Connect(Opcion5, Opcion3, "Vas a comprar $456.00 en moldes.");
            Connect(Opcion6, Opcion3, "Le preguntas a la vendedora para que sirve el pedestal de $1200.00.");

            Opcion principal = Opcion1;
            while (true)
            {
                Console.WriteLine($"{principal.respuesta}");
                int x = 1;
                if (principal.opciones.Count == 0)
                    break;
                for (int i = 0; i < principal.opciones.Count; i++)
                {
                    Console.WriteLine($"{x}. {principal.conexiones[i]}");
                    x++;
                }

                while(true)
                {
                    Console.Write("Escoge tu camino: ");
                    try
                    {
                        int respuesta = int.Parse(Console.ReadLine());
                        principal = principal.opciones[respuesta-1];
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Opcion no válida.");
                    }
                }
            }
        }
        public static bool Connect(Opcion c1, Opcion c2, string conexion) 
        {
            if (c1.opciones.Contains(c2))
            {
                return false;
            }

            c1.opciones.Add(c2);
            c1.conexiones.Add(conexion);
            return true;
        }
    }

    //Cada instancia de la clase Opcion representa un nodo en el árbol. 
    //Los campos "opciones" y "conexiones" se utilizan para definir las relaciones entre los nodos en el árbol.
    public class Opcion
    {
        public string respuesta;
        public List<Opcion> opciones;
        public List<string> conexiones;

        //Toma un argumento de tipo string, que es el texto de respuesta para la opción
        public Opcion(string respuesta)
        {
            this.respuesta=respuesta;
            opciones = new List<Opcion>();
            conexiones = new List<string>();
        }
    }
}

