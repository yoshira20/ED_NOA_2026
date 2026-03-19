using System;
using System.Collections.Generic;

namespace EjerciciosListas
{
    public class Ejercicio5
    {
        private List<int> numeros;

        public Ejercicio5()
        {
            numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }
        }

        public void Ejecutar()
        {
            Console.WriteLine("=== EJERCICIO 5: Números en Orden Inverso ===");
            numeros.Reverse();
            Console.WriteLine("Números del 1 al 10 en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros));
            Console.WriteLine();
        }
    }
}