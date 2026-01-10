using System;
using System.Collections.Generic;
using System.Linq;  // ← Esta línea es CRUCIAL

namespace EjerciciosListas
{
    public class Ejercicio8
    {
        public void Ejecutar()
        {
            Console.WriteLine("=== EJERCICIO 8: Verificador de Palíndromos ===");
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine();
            
            if (EsPalindromo(palabra))
            {
                Console.WriteLine($"'{palabra}' SÍ es un palíndromo.");
            }
            else
            {
                Console.WriteLine($"'{palabra}' NO es un palíndromo.");
            }
            Console.WriteLine();
        }

        private bool EsPalindromo(string palabra)
        {
            palabra = palabra.ToLower().Replace(" ", "");
            List<char> caracteres = palabra.ToList();
            List<char> caracteresInvertidos = new List<char>(caracteres);
            caracteresInvertidos.Reverse();
            return caracteres.SequenceEqual(caracteresInvertidos);
        }
    }
}