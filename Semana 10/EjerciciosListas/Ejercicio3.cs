using System;
using System.Collections.Generic;

namespace EjerciciosListas
{
    public class Ejercicio3
    {
        private List<string> asignaturas;
        private Dictionary<string, double> notasPorAsignatura;

        public Ejercicio3()
        {
            asignaturas = new List<string> 
            { 
                "Matemáticas", 
                "Física", 
                "Química", 
                "Historia", 
                "Lengua" 
            };
            notasPorAsignatura = new Dictionary<string, double>();
        }

        public void Ejecutar()
        {
            Console.WriteLine("=== EJERCICIO 3: Asignaturas y Notas ===");
            SolicitarNotas();
            MostrarResultados();
        }

        private void SolicitarNotas()
        {
            foreach (string asignatura in asignaturas)
            {
                double nota = 0;
                bool entradaValida = false;

                while (!entradaValida)
                {
                    Console.Write($"Ingrese la nota de {asignatura}: ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out nota) && nota >= 0 && nota <= 10)
                    {
                        notasPorAsignatura[asignatura] = nota;
                        entradaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese una nota válida entre 0 y 10.");
                    }
                }
            }
        }

        private void MostrarResultados()
        {
            Console.WriteLine("\n--- Resultados ---");
            foreach (var par in notasPorAsignatura)
            {
                Console.WriteLine($"En {par.Key} has sacado {par.Value}");
            }
            Console.WriteLine();
        }
    }
}