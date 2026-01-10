using System;
using System.Collections.Generic;

namespace EjerciciosListas
{
    public class Ejercicio1
    {
        private List<string> asignaturas;

        public Ejercicio1()
        {
            asignaturas = new List<string> 
            { 
                "Matemáticas", 
                "Física", 
                "Química", 
                "Historia", 
                "Lengua" 
            };
        }

        public void Ejecutar()
        {
            Console.WriteLine("=== EJERCICIO 1: Lista de Asignaturas ===");
            Console.WriteLine("Asignaturas del curso:");
            
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine($"- {asignatura}");
            }
            Console.WriteLine();
        }
    }
}