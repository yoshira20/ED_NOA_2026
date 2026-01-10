using System;

namespace EjerciciosListas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║  EJERCICIOS DE LISTAS EN C# CON POO       ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();

            bool continuar = true;

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        var ejercicio1 = new Ejercicio1();
                        ejercicio1.Ejecutar();
                        break;
                    case "3":
                        var ejercicio3 = new Ejercicio3();
                        ejercicio3.Ejecutar();
                        break;
                    case "5":
                        var ejercicio5 = new Ejercicio5();
                        ejercicio5.Ejecutar();
                        break;
                    case "7":
                        var ejercicio7 = new Ejercicio7();
                        ejercicio7.Ejecutar();
                        break;
                    case "8":
                        var ejercicio8 = new Ejercicio8();
                        ejercicio8.Ejecutar();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("┌─────────────────────────────────────────┐");
            Console.WriteLine("│           MENÚ DE EJERCICIOS            │");
            Console.WriteLine("├─────────────────────────────────────────┤");
            Console.WriteLine("│ 1. Ejercicio 1: Lista de Asignaturas    │");
            Console.WriteLine("│ 3. Ejercicio 3: Asignaturas y Notas     │");
            Console.WriteLine("│ 5. Ejercicio 5: Números Inversos        │");
            Console.WriteLine("│ 7. Ejercicio 7: Abecedario Filtrado     │");
            Console.WriteLine("│ 8. Ejercicio 8: Verificar Palíndromo    │");
            Console.WriteLine("│ 0. Salir                                │");
            Console.WriteLine("└─────────────────────────────────────────┘");
            Console.Write("Seleccione una opción: ");
        }
    }
}
