using System;

namespace RegistroEstudiantes
{
    // Definición de la clase Estudiante
    // Una clase es un modelo o plantilla que define las características (propiedades)
    // y comportamientos (métodos) de un objeto
    public class Estudiante
    {
        // Propiedades de la clase (atributos del estudiante)
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        
        // Array para almacenar tres números de teléfono
        // Un array es una estructura de datos que almacena múltiples valores
        // del mismo tipo en posiciones consecutivas de memoria
        public string[] Telefonos { get; set; }

        // Constructor de la clase
        // Se ejecuta automáticamente al crear una nueva instancia del objeto
        public Estudiante()
        {
            // Inicializamos el array de teléfonos con capacidad para 3 elementos
            Telefonos = new string[3];
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("    INFORMACIÓN DEL ESTUDIANTE");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine($"ID:         {ID}");
            Console.WriteLine($"Nombres:    {Nombres}");
            Console.WriteLine($"Apellidos:  {Apellidos}");
            Console.WriteLine($"Dirección:  {Direccion}");
            Console.WriteLine("\nTeléfonos:");
            
            // Recorremos el array de teléfonos usando un bucle for
            for (int i = 0; i < Telefonos.Length; i++)
            {
                if (!string.IsNullOrEmpty(Telefonos[i]))
                {
                    Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
                }
            }
            Console.WriteLine("═══════════════════════════════════════\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE REGISTRO DE ESTUDIANTES         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");

            // Creamos una instancia de la clase Estudiante
            Estudiante estudiante = new Estudiante();

            // Captura de datos del estudiante
            Console.Write("Ingrese el ID del estudiante: ");
            estudiante.ID = int.Parse(Console.ReadLine());

            Console.Write("Ingrese los nombres: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Ingrese la dirección: ");
            estudiante.Direccion = Console.ReadLine();

            // Captura de los tres números de teléfono
            Console.WriteLine("\n--- Registro de Teléfonos ---");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Ingrese el teléfono {i + 1}: ");
                estudiante.Telefonos[i] = Console.ReadLine();
            }

            // Mostramos la información registrada
            estudiante.MostrarInformacion();

            // Ejemplo de trabajo con arrays adicionales
            Console.WriteLine("\n--- EJEMPLO DE ARRAYS Y MATRICES ---\n");

            // Array unidimensional (vector)
            int[] numeros = { 10, 20, 30, 40, 50 };
            Console.WriteLine("Array unidimensional:");
            Console.Write("Valores: ");
            foreach (int num in numeros)
            {
                Console.Write($"{num} ");
            }

            // Matriz bidimensional (tabla)
            int[,] matriz = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Console.WriteLine("\n\nMatriz bidimensional 3x3:");
            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {
                    Console.Write($"{matriz[fila, columna],4}");
                }
                Console.WriteLine();
            }

            // Array de objetos (array de estudiantes)
            Estudiante[] listaEstudiantes = new Estudiante[2];
            listaEstudiantes[0] = estudiante; // El estudiante registrado
            
            Console.WriteLine("\n\n--- Presione cualquier tecla para salir ---");
            Console.ReadKey();
        }
    }
}

/*
═══════════════════════════════════════════════════════════════════
CONCEPTOS FUNDAMENTALES:

1. CLASES:
   - Son plantillas para crear objetos
   - Definen propiedades (datos) y métodos (comportamientos)
   - Ejemplo: La clase Estudiante define qué datos tiene un estudiante

2. ARRAYS (Arreglos):
   - Colección de elementos del mismo tipo
   - Tamaño fijo definido al momento de creación
   - Acceso mediante índices (empiezan en 0)
   - Ejemplo: string[] telefonos = new string[3];

3. MATRICES:
   - Arrays multidimensionales (2D, 3D, etc.)
   - Se declaran con comas: int[,] matriz
   - Útiles para representar tablas o grillas
   - Ejemplo: int[,] matriz = new int[3,3];

═══════════════════════════════════════════════════════════════════
*/