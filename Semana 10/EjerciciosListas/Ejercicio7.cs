using System;
using System.Collections.Generic;

namespace EjerciciosListas
{
    public class Ejercicio7
    {
        private List<char> abecedario;

        public Ejercicio7()
        {
            abecedario = new List<char>();
            for (char letra = 'a'; letra <= 'z'; letra++)
            {
                abecedario.Add(letra);
            }
        }

        public void Ejecutar()
        {
            Console.WriteLine("=== EJERCICIO 7: Abecedario sin Múltiplos de 3 ===");
            Console.WriteLine("Abecedario original:");
            MostrarAbecedario(abecedario);
            EliminarMultiplosDeTres();
            Console.WriteLine("\nAbecedario después de eliminar múltiplos de 3:");
            MostrarAbecedario(abecedario);
            Console.WriteLine();
        }

        private void EliminarMultiplosDeTres()
        {
            List<char> nuevaLista = new List<char>();
            for (int i = 0; i < abecedario.Count; i++)
            {
                if ((i + 1) % 3 != 0)
                {
                    nuevaLista.Add(abecedario[i]);
                }
            }
            abecedario = nuevaLista;
        }

        private void MostrarAbecedario(List<char> lista)
        {
            Console.WriteLine(string.Join(", ", lista));
        }
    }
}